using FilesApi.Domain.Entities;
using FilesApi.Aplication.FileRepository.Repositories;
using FilesApi.Controllers.Common;
namespace FilesApi.Controllers.Services
{
    public class FileRepositoryService : IGenericService<FileRepositoryModel>
    {
        public  FileRepositoryRepo _repository = new FileRepositoryRepo();

        public FileRepositoryService()
        {
           

            
        }
        public async Task<FileRepositoryModel> Create(FileRepositoryModel entity)
        {
            return await _repository.Add(entity);
        }

        public Task Delete(FileRepositoryModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<FileRepositoryModel> Get(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<FileRepositoryModel> GetBySerialNumber(string serialNumber)
        {
          return  await _repository.GetBySerialNumber(serialNumber);
          
        }
       

        public Task<IEnumerable<FileRepositoryModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(FileRepositoryModel entity)
        {
            throw new NotImplementedException();
        }
    }
}