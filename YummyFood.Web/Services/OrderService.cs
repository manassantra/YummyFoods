using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Models;

namespace YummyFood.Web.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _httpClient;
        public OrderService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<T> CreateOrder<T>(int uId, OrderBO order, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAllOrders<T>(string token)
        {
            var client = new HttpClient();
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.GET,
                Url = ServiceDirectory.ApiGateway + "/order-gateway",
                AccessToken = token
            });
        }

        public Task<T> GetAllOrders<T>(int orderId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllOrdersByUserId<T>(int uId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
