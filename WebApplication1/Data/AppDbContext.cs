using Microsoft.EntityFrameworkCore;
using TechnicalTask.Models;

namespace TechnicalTask.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
