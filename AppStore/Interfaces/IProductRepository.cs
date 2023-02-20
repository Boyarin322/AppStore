using AppStore.Models;

namespace AppStore.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<bool> Create(Product entity);
        public Task<Product> GetValue(Guid id);
        public Task<List<Product>> Select();
        public Task<bool> Delete(Guid id);
        public IQueryable<Product> GetAll();

    }
}
