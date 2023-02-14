namespace AppStore.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<List<T>> Select();
    }
}
