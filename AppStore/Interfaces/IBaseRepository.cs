namespace AppStore.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<T> GetValue(int id);  
        Task<List<T>> Select();
        bool Delete(T entity);
    }
}
