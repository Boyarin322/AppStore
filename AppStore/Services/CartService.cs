using AppStore.Interfaces;
using AppStore.Models;
using AppStore.Responses;

namespace AppStore.Services
{
    public class CartService : ICartService
    {
        private readonly IBaseRepository<Cart> _cartRepository;

        public CartService(IBaseRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<BaseResponse<Cart>> GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}