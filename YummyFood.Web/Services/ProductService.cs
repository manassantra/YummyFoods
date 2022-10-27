using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Models;

namespace YummyFood.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClient;
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreateProductAsync<T>(ProductBO productBO)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.POST,
                Data = productBO,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/create",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.DELETE,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.GET,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/Products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.GET,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductBO productBO)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.PUT,
                Data = productBO,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/update",
                AccessToken = ""
            });
        }
    }
}
