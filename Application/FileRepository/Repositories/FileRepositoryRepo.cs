using System;
using System.IO.Compression;
using FilesApi.Domain.Entities;
using FilesApi.Infrastructure.Persistansce.StoreProcedureRepo;

namespace FilesApi.Aplication.FileRepository.Repositories
{
     
    public class FileRepositoryRepo : IGenericRepository<FileRepositoryModel>
    {
        StoreProceduresRepo _storeProceduresRepo = new StoreProceduresRepo();

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>FileRepositoryModel</returns>        
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

        
        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FileRepositoryModel</returns>

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


        /// <summary>
        /// GetBySerialNumber
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns>FileRepositoryModel</returns>        
        public Task<FileRepositoryModel> GetBySerialNumber(string serialNumber)
        {
            return Task.FromResult(_storeProceduresRepo.GetFileRepositoryBySerialNumer(serialNumber));         
        }

      

        //get zipfiles From Tuple<string, byte[]> string = serialNumber, byte[] = fileData
        public Task<byte[]> GetZipFilesFromList(string serialNumbers)
        {
            var listFiles = _storeProceduresRepo.GetFilesFromList(serialNumbers);
            List<Tuple<string, byte[]>> listSerialAndFileData = new List<Tuple<string, byte[]>>();
            foreach (var item in listFiles)
            {
                listSerialAndFileData.Add(new Tuple<string, byte[]>(item.SerialNumber, item.FileData));
            }
            return CreateZipFile(listSerialAndFileData);
        }
        public Task<byte[]> CreateZipFile(List<Tuple<string, byte[]>> listSerialAndFileData)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var item in listSerialAndFileData)
                    {
                        ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntry(item.Item1 + ".dat");
                        using (BinaryWriter binaryWriter = new BinaryWriter(zipArchiveEntry.Open()))
                        {
                            binaryWriter.Write(item.Item2);
                        }
                    }
                }
                return Task.FromResult(memoryStream.ToArray());
            }
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