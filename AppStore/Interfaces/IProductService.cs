using AppStore.Models;
using AppStore.Models.ViewModels;
using AppStore.Responses;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace AppStore.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<bool>> DeleteProduct(Guid id);

        public Task<BaseResponse<bool>> CreateProduct(CreateProductViewModel model);
        public Task<BaseResponse<IEnumerable<GetProductsViewModel>>> GetProducts();
    }
}
