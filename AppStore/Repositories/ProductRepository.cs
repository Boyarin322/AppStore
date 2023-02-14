using AppStore.Interfaces;
using AppStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Product entity)
        {
           await _db.AddAsync<Product>(entity);
           await _db.SaveChangesAsync();
           return true;
        }

        public async Task<bool> Delete(Product entity)
        {
            var product = _db.Products.FirstOrDefault(entity);
            if (product == null)
            {
                return false;
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Product> GetAll()
        {
            return _db.Products;
        }

        public async Task<Product> GetValue(string productname)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Productname == productname);
            if (product == null)
            {
                throw new Exception();
            }
            return product;
        }

        public async Task<List<Product>> Select()
        {
            return await _db.Products.ToListAsync();
        }
    }
}
