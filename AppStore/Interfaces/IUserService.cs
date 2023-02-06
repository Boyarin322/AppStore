using AppStore.Models;
using AppStore.Models.ViewModels;
using AppStore.Responses;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppStore.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Logger(LoggerViewModel model);

        Task<BaseResponse<bool>> DeleteUser(int id);
    }
}
