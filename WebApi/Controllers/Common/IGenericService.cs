namespace FilesApi.Controllers.Common
{
    public interface IGenericService<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);

        Task Delete(T entity);
    }
}