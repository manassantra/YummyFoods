using IdentityServiceGateway.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServiceGateway.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}

