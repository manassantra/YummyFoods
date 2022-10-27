namespace OrderServiceGateway.CommonBO
{
    public class OrderDetailsBO
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
