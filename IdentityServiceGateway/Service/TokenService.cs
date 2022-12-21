using IdentityServiceGateway.Models;
using IdentityServiceGateway.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityServiceGateway.Service
{
    public class TokenService : ITokenService
    {
        public IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }


        // Create Jwt-Auth-Token for Admin
       /* public string GetTokenForAdmin(Admin admin)
        {
            var jwt = _config.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("Id", admin.Id.ToString()),
                        new Claim("Email", admin.Email.ToString()),
                      //  new Claim("Role", admin.Role.ToString()),
                        new Claim("Password", admin.PasswordHash.ToString()),
                        new Claim("Password", admin.PasswordSalt.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
*/

        // Create Jwt-Auth-Token for User
        public string GetTokenForUser(User user)
        {
            var jwt = _config.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Email", user.Email.ToString()),
                      //  new Claim("Role", user.Role.ToString()),
                        new Claim("Password", user.PasswordHash.ToString()),
                        new Claim("Password", user.PasswordSalt.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
