using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0306.Models
{
    // Here is the datacontext file that hooks up all of the files together. It is linked between Tasks, Quadrants,
    // and Categories 
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
