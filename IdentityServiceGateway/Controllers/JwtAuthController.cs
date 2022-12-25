using IdentityServiceGateway.CommonBO;
using IdentityServiceGateway.DbContexts;
using IdentityServiceGateway.Models;
using IdentityServiceGateway.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace IdentityServiceGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JwtAuthController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly ITokenService _jwtService;

        public JwtAuthController(AppDbContext context, ITokenService jwtService)
        {
            _jwtService = jwtService;
            _context = context;
        }

        // Signup
        [HttpPost("signup")]
        public async Task<object> SignupJwtToken(SignupBO userBo)
        {
            if (userBo.FullName != null && userBo.Email != null && userBo.Password != null)
            {
                if (await UserExist(userBo.Email)) return BadRequest("User Already Exist !");

                try
                {
                    using var hmac = new HMACSHA512();
                    var usr = new User
                    {
                        FullName = userBo.FullName,
                        Email = userBo.Email,
                        Role = "User",
                        PasswordHash = hmac.ComputeHash(Encoding.UTF32.GetBytes(userBo.Password)),
                        PasswordSalt = hmac.Key,
                        Mob = userBo.Mob
                    };

                    _context.Users.Add(usr);
                    await _context.SaveChangesAsync();

                    var authToken = _jwtService.GetTokenForUser(usr);
                    return new AuthResponseBO
                    {
                        uId = usr.Id,
                        userName = usr.Email,
                        uToken = authToken,
                        message = "Signup Successfull."
                    };

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            else
            {
                return BadRequest("Please fill all field Carefully.");
            }
        }

        private async Task<bool> UserExist(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

        // Login
        [HttpPost("login")]
        public async Task<object> LoginJwtToken(LoginBO userBo)
        {
            if (userBo.Username != null && userBo.Password != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Email.ToLower() == userBo.Username.ToLower());

                if (user == null) return Unauthorized("Invalid User");

                try
                {
                    using var hmac = new HMACSHA512(user.PasswordSalt);
                    var computedHash = hmac.ComputeHash(Encoding.UTF32.GetBytes(userBo.Password));

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Wrong Password");
                    }

                    var authToken = _jwtService.GetTokenForUser(user);
                    return new AuthResponseBO
                    {
                        uId = user.Id,
                        uToken = authToken,
                        userName = user.Email,
                        message = "Signin Successfull."
                    };

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Please check username/password");
            }
        }


        // Test Auth-Token
        [Authorize]
        [HttpGet("test-jwt-token")]
        public string TestAuthToken()
        {
            return "Jwt-Token Working.";
        }

    }
}
