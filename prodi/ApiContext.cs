using Microsoft.EntityFrameworkCore;
using prodi.Models;

namespace prodi
{
    /// <summary>
    /// The API's database context
    /// </summary>
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
