using OrderServiceGateway.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderServiceGateway.CommonBO
{
    public class OrderBO
    {
        public int OrderId { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public double TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public string? PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
