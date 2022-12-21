using IdentityServiceGateway.Models;

namespace IdentityServiceGateway.Service.Interface
{
    public interface ITokenService
    {
        string GetTokenForUser(User user);
     //   string GetTokenForAdmin(Admin admin);
    }
}
