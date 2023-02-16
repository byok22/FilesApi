using System;
using FilesApi.Domain.Entities;
using FilesApi.Infrastructure.Persistansce.StoreProcedureRepo;

namespace FilesApi.Aplication.FileRepository.Repositories
{
     
    public class FileRepositoryRepo : IGenericRepository<FileRepositoryModel>
    {
        StoreProceduresRepo _storeProceduresRepo = new StoreProceduresRepo();
        public Task<FileRepositoryModel> Add(FileRepositoryModel entity)
        {
            return Task.FromResult(_storeProceduresRepo.InsertAndGetFileRepositoryModel(entity));            
        }

        public Task Delete(FileRepositoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FileRepositoryModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FileRepositoryModel> GetById(int id)
        {
            return Task.FromResult(new FileRepositoryModel
            {
                 
                PKFile   = 1,
                FileName = "Test",
                SerialNumber = "FE222347210269",
                FKProcess = 1,
                Source = "Test",
                FileData = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },               
                UpdatedAt = DateTime.Now                
               
            });
         
        }
        public Task<FileRepositoryModel> GetBySerialNumber(string serialNumber)
        {
            return Task.FromResult(_storeProceduresRepo.GetFileRepositoryBySerialNumer(serialNumber));         
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(FileRepositoryModel entity)
        {
            throw new NotImplementedException();
        }
    }


}