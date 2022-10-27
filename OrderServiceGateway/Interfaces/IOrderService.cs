using OrderServiceGateway.CommonBO;

namespace OrderServiceGateway.Interfaces
{
    public interface IOrderService
    {
        // Order Service
        Task<IEnumerable<OrderBO>> GetOrder();
        Task<OrderBO> GetOrder(int orderId);
        Task<OrderBO> CreateOrder(OrderBO orderBO);
     //   Task<OrderBO> UpdateOrder(OrderBO orderBO);
      //  Task<bool> DeleteOrder(int id);
    }
}
