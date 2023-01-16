using OrderServiceGateway.CommonBO;

namespace OrderServiceGateway.Interfaces
{
    public interface IOrderService
    {
        // Order Service
        Task<IEnumerable<OrderBO>> GetOrder();
        Task<IEnumerable<OrderBO>> SearchOrder(int key);
        Task<OrderBO> GetOrderById(int orderId);
        Task<OrderBO> CreateOrder(OrderBO orderBO);

    }
}
