using Newtonsoft.Json.Linq;
using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Models;

namespace YummyFood.Web.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _httpClient;
        public UserService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetUserById<T>(int userId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.GET,
                // Url = ServiceDirectory.ProductAPIBase + "/api/v1/products/" + id,
                Url = ServiceDirectory.ApiGateway + "/user-gateway/" + userId,
                AccessToken = token
            });
        }
    }
}
