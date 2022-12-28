
namespace YummyFood.Web.Models
{
    public class AuthResponse
    {
        public int uId { get; set; }
        public string? uToken { get; set; }
        public string? userName { get; set; }
        public string? message { get; set; }
    }
}
