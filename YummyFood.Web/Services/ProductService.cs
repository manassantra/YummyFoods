using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text;
using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Models;
using static System.Net.WebRequestMethods;

namespace YummyFood.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClient;
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreateProductAsync<T>(ProductBO productBO, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.POST,
                Data = productBO,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/create",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.DELETE,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/" + id,
                AccessToken = token,
            }) ;
        }

        public async Task<T> GetAllProductAsync<T>(string token)
        {
            var client = new HttpClient();
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.GET,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/Products",
                AccessToken = token
        });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.GET,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductBO productBO, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.PUT,
                Data = productBO,
                Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/update",
                AccessToken = token
            });
        }
    }
}
