using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOF.Domain.Entities;

namespace MOF.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }




        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
