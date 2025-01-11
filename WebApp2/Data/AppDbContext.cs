using Microsoft.EntityFrameworkCore;
using WebApp2.Models;

namespace WebApp2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
