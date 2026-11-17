using EF_Core_Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Sample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
