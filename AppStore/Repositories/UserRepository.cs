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
            await _db.AddAsync<User>(entity);   
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return false;
            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetValue(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                throw new Exception();
            }
            return user;
        }
        public async Task<User> GetValue(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Username == username);
            if(user == null)
            {
                throw new Exception();
            }
            return user;
        }

        public async Task<List<User>> Select()
        {
            return await _db.Users.ToListAsync();
        }
        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }
    }
}
