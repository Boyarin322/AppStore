using AppStore.Models;

namespace AppStore.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> Create(User entity);
        Task<User> GetValue(int id);
        Task<List<User>> Select();
        bool Delete(User entity);
    }
}
