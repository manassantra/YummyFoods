using System.ComponentModel.DataAnnotations;

namespace OrderServiceGateway.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public List<OrderDetail>? OrderDetails { get; set; }

        [Required]
        public double TotalPrice { get; set; }
        public int TotalItem { get; set; }
        public int OrderStatus { get; set; }
        public string? PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
