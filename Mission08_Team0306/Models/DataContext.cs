using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0306.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        { 
        }

        public DbSet<TaskViewModel> Tasks { get; set; }

        public DbSet<Quadrant> Quadrants { get; set; }

        public DbSet<Categories> Categories { get; set; }

    }
}
