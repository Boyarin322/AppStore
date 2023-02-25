using AppStore.Interfaces;
using AppStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Repositories
{
    public class CartRepository : IBaseRepository<Cart>
    {
        private readonly ApplicationDbContext _db;
        public CartRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Cart entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var cart = await _db.Carts.FirstOrDefaultAsync(p => p.Id == id);
            if (cart == null) {
                return false;
            }
             _db.Remove(id);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Cart> GetAll()
        {
            return _db.Carts.AsQueryable();
        }

        public async Task<Cart> GetValue(Guid id)
        {
            var cart = await _db.Carts.FirstOrDefaultAsync(p => p.Id == id);
          
            return cart;
        }


    }
}
