using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TaskItem> Tasks
        {
            get; set;
        }
    }
}