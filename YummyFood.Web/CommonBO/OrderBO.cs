
namespace YummyFood.Web.CommonBO
{
    public class OrderBO
    {
        public int OrderId { get; set; }
        public List<OrderDetailBO>? OrderDetails { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItem { get; set; }
        public int OrderStatus { get; set; }
        public string? PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
