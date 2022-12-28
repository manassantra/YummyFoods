namespace YummyFood.Web.CommonBO
{
    public class OrderDetailBO
    {
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
