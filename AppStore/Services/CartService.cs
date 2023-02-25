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

        public async Task<BaseResponse<bool>> AddToCart(Guid userID, Guid productID)
        {
            try
            {
                var cart = new Cart(userId: userID, productId: productID);
                var result = await _cartRepository.Create(cart);
                return new BaseResponse<bool> { 
                    Data = result,
                    StatusCode= Enums.StatusCode.Success,
                    Description="Added to cart"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Data=false,
                    Description = ex.Message,
                    StatusCode = Enums.StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<Cart>>> GetCart(Guid id)
        {
            var response = new BaseResponse<IEnumerable<Cart>>();
            try
            {
                var cart = _cartRepository.GetAll().Where(x => x.Id == id);
                if (cart == null)
                {
                    response.StatusCode = Enums.StatusCode.NotFound;
                    response.Description = "not found";
                    return response;
                }
                response.StatusCode = Enums.StatusCode.Success;
                response.Data = cart;
                return response;
            }
            catch (Exception ex)
        {
                response.StatusCode = Enums.StatusCode.InternalServerError;
                response.Description = ex.Message;
                return response;
            }
        }
    }
}