using AppStore.Models;

namespace AppStore.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<bool> Create(User entity);

        public Task<User> GetValue(string username);
        public Task<List<User>> Select();
        public Task<bool> Delete(Guid id);
        public IQueryable<User> GetAll();
    }
}
