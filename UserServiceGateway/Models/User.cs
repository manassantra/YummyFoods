using System.ComponentModel.DataAnnotations.Schema;

namespace UserServiceGateway.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Role { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int Mob { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

    }
}
