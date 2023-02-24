using AppStore.Models;
using AppStore.Models.ViewModels;
using AppStore.Responses;

namespace AppStore.Interfaces
{
    public interface ICartService
    {
        public Task<BaseResponse<Cart>> GetProduct(Guid id);
    }
}
