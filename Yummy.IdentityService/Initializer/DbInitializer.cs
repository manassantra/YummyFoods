using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Yummy.IdentityService.DbContexts;
using Yummy.IdentityService.Models;

namespace Yummy.IdentityService.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext  _dbContext;
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly RoleManager<IdentityRole>  _roleManager;

        public DbInitializer(AppDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
    
        public void Initialize()
        {
            if(_roleManager.FindByNameAsync(ServiceDirectory.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(ServiceDirectory.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(ServiceDirectory.Customer)).GetAwaiter().GetResult();
            } else
            {
                return;
            }

            // CREATE  ADMIN-USER

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "secretAdmin@gmail.com",
                Email = "secretAdmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "9876543210",
                FirstName = "Admin",
                LastName = "User"
            };

            _userManager.CreateAsync(adminUser, "Admin@1234").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, ServiceDirectory.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName+ " " +adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, ServiceDirectory.Admin),

            }).Result;


            // CREATE  CUSTOMER-USER

            ApplicationUser custUser = new ApplicationUser()
            {
                UserName = "manassantra.contact@gmail.com",
                Email = "manassantra.contact@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "9851058072",
                FirstName = "Manas",
                LastName = "Santra"
            };

            _userManager.CreateAsync(custUser, "Admin@1234").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(custUser, ServiceDirectory.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(custUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, custUser.FirstName+ " " +custUser.LastName),
                new Claim(JwtClaimTypes.GivenName, custUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, custUser.LastName),
                new Claim(JwtClaimTypes.Role, ServiceDirectory.Customer),

            }).Result;
        }
    }
}
