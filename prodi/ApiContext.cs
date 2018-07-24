using Microsoft.EntityFrameworkCore;
using prodi.Models;

namespace prodi
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
