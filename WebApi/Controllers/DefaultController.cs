using Microsoft.AspNetCore.Mvc;

namespace FilesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DefaultController : ControllerBase
{
   

    private readonly ILogger<DefaultController> _logger;

    public DefaultController(ILogger<DefaultController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("/")]
    [Route("/docs")]
    [Route("/swagger")]
    public IActionResult Index()
    {
         return new RedirectResult("~/swagger");
    }
}
