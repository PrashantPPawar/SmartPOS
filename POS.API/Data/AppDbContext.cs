using Microsoft.EntityFrameworkCore;
using POS.API.DTOs;
namespace POS.API.Data
{
    public class AppDbContext : DbContext
    {
        ////public DbSet<Prod> Products { get; set; }
        
        public DbSet<EmployeeDto> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
