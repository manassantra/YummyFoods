using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderServiceGateway.CommonBO;
using OrderServiceGateway.DbContexts;
using OrderServiceGateway.Interfaces;
using OrderServiceGateway.Models;


namespace OrderServiceGateway.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _dbContexts;
        private readonly IMapper _iMapper;

        public OrderService(AppDbContext appDbContext, IMapper iMapper)
        {
            _dbContexts = appDbContext;
            _iMapper = iMapper;
        }

        public async Task<OrderBO> CreateOrder(OrderBO orderBO)
        {
            foreach (var item in orderBO.OrderDetails)
            {
                orderBO.TotalPrice = (item.Quantity * item.Price);
                orderBO.TotalItem += item.Quantity; 
            }
            Order order = _iMapper.Map<OrderBO, Order>(orderBO);
            _dbContexts.Add(order);
            await _dbContexts.SaveChangesAsync();
            return _iMapper.Map<Order, OrderBO>(order);
        }

        public async Task<OrderBO> GetOrder(int orderId)
        {
            var order = await _dbContexts.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
            List<OrderDetail> orderDetails = await _dbContexts.OrderDetails.Where(x => x.OrderId == orderId).ToListAsync();
            order.OrderDetails = orderDetails;  
            return _iMapper.Map<OrderBO>(order);
        }

        public async Task<IEnumerable<OrderBO>> GetOrder()
        {
            List<Order> orderList = await _dbContexts.Orders.ToListAsync();
            foreach (var order in orderList)
            {
                List<OrderDetail> orderDetails = await _dbContexts.OrderDetails.Where(x => x.OrderId == order.OrderId).ToListAsync();
                order.OrderDetails = orderDetails;
            }
            
            return _iMapper.Map<IEnumerable<OrderBO>>(orderList);
        }
    }
}
