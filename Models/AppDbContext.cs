using Microsoft.EntityFrameworkCore; 

namespace TaskApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
