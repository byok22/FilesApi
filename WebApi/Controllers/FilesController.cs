using FilesApi.Controllers.Services;
using FilesApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
   

    private readonly ILogger<DefaultController> _logger;

    private readonly FileRepositoryService _service = new FileRepositoryService();

    public FilesController(ILogger<DefaultController> logger)
    {
        _logger = logger;
    }
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] FileRepositoryModel file)
    {
        _logger.LogInformation("Creating file");
       await _service.Create(file);
        return Ok(file);
    }


    [HttpGet]
    [Route("get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _service.Get(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }    
    [HttpGet]  
    [Route("getFiles")]  
    public IActionResult GetFiles()
    {
        return Ok("Hola mundo");
    }


    [HttpGet]  
    [Route("getbyserialnumber/{serialNumber}")]           
    public async Task<IActionResult> GetBySerialNumber(string serialNumber)
    {
        var item = await _service.GetBySerialNumber(serialNumber);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    [Route("UploadFile")]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
        //check if file extension is .DAT or .dat
        if (Path.GetExtension(file.FileName) != ".DAT" && Path.GetExtension(file.FileName) != ".dat")
        {
            return BadRequest("Invalid file extension");
        }
        //convert file to byte array
        byte[] fileBytes;
        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            fileBytes = ms.ToArray();
        }
        FileRepositoryModel fileToUpload = new FileRepositoryModel();
        fileToUpload.FileData = fileBytes;
        fileToUpload.FileName = file.FileName;      
        //Get File name without extension        
        fileToUpload.SerialNumber = Path.GetFileNameWithoutExtension(file.FileName);
        fileToUpload.UpdatedAt = DateTime.Now;
        //Get Source Fiel from body of http request
        fileToUpload.Source = Request.Form["Source"];
        await _service.Create(fileToUpload);      
        return Ok(fileToUpload);
    }
}
   
