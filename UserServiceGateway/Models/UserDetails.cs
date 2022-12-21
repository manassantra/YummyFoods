namespace UserServiceGateway.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ImageUrl { get; set; }
        public List<object>? UserAddress { get; set; }
        public List<object>? OrderList { get; set; }
        public List<object>? PaymentDetails { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsMobConfirmed { get; set; }
        public bool IsActive { get; set; }
    }
}
