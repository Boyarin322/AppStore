using AppStore.Interfaces;
using AppStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(User entity)
        {
            await _db.Users.AddAsync(entity);   
            await _db.SaveChangesAsync();
            return true;
        }

        public bool Delete(User entity)
        {
             _db.Users.Remove(entity);
             _db.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetValue(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> GetValue(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<List<User>> Select()
        {
            return await _db.Users.ToListAsync();
        }
        
    }
}
