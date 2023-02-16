using FilesApi.Aplication;

namespace FilesApi.Controllers.Common
{
    public class GenericService<T>: IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
      
       
        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        
      
        public async Task<T> Create(T entity)
        {
            return await _repository.Add(entity);
        }

        public Task Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _repository.GetById(id);
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Update(T entity)
        {
             await _repository.Update(entity);
        }
    }

}