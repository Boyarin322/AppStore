namespace AppStore.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        public Task<bool> Delete(Guid id);
        public IQueryable<T> GetAll();
        public Task<T> GetValue(Guid id);
    }
}
