using AppStore.Models;

namespace AppStore.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<bool> Create(Product entity);
        Task<Product> GetValue(string productname);
        Task<List<Product>> Select();
        public Task<bool> Delete(Guid id);
        public IQueryable<Product> GetAll();

    }
}
