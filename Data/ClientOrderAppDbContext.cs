using Microsoft.EntityFrameworkCore;

namespace ClientOrderApp.Data
{
    public class ClientOrderAppDbContext : DbContext
    {
        public ClientOrderAppDbContext(DbContextOptions<ClientOrderAppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Order> Orders { get; set; }

    }
}
