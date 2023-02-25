using AppStore.Models;
using AppStore.Models.ViewModels;
using AppStore.Responses;

namespace AppStore.Interfaces
{
    public interface ICartService
    {
        public Task<BaseResponse<IEnumerable<Cart>>> GetCart(Guid userID);

        public Task<BaseResponse<bool>> AddToCart(Guid userID, Guid productID);
    }
}
