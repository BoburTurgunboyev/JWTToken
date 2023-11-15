using JWTToken.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTToken.DataAccess
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }

    }
}
