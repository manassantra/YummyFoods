using YummyFood.Web.CommonBO;

namespace YummyFood.Web.Interfaces
{
    public interface IOrderService
    {
        Task<T> GetAllOrders<T>(string token);
        Task<T> GetAllOrders<T>(int orderId, string token);
        Task<T> SearchOrders<T>(int key, string token);
        Task<T> CreateOrder<T>(int uId, OrderBO order, string token);

    }
}
