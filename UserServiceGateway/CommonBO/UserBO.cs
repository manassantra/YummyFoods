namespace UserServiceGateway.CommonBO
{
    public class UserBO
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int Mob { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public List<object>? UserDetails { get; set; }
    }
}
