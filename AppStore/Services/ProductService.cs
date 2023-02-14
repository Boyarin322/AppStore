using AppStore.Enums;
using AppStore.Interfaces;
using AppStore.Models.ViewModels;
using AppStore.Models;
using AppStore.Repositories;
using AppStore.Responses;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<BaseResponse<bool>> DeleteProduct(Guid id)
        {
            try
            {
                await _productRepository.Delete(id);
                return new BaseResponse<bool>
                {
                    Data = true,
                    Description = "Product deleted",
                    StatusCode = Enums.StatusCode.Success
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    Description = ex.Message,
                    StatusCode = Enums.StatusCode.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<IEnumerable<GetProductsViewModel>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();

            try
            {
                var products = await _productRepository.GetAll()
                 .Select(x => new GetProductsViewModel()
                 {
                     Id = x.Id,
                     Productname = x.Productname,
                     Description = x.Description,
                     Price = x.Price
                 })
             .ToListAsync();

                return new BaseResponse<IEnumerable<GetProductsViewModel>>()
                {
                    Data = products,
                    StatusCode = StatusCode.Success,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GetProductsViewModel>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = ex.Message
                };


            }
        }
        public async Task<BaseResponse<bool>> CreateProduct(CreateProductViewModel model)
        {
            try
            {
                Product product = new(
                    model.Price,
                    model.Productname,
                    model.Description
                    );

                var responce = await _productRepository.Create(product);
                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.Success,
                    Description = "Product created",
                    Data = true
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = ex.Message,
                    Data= false
                };
            }
        }
    }
}
