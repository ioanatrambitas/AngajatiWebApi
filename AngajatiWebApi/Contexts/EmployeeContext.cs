using AngajatiWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Task = AngajatiWebApi.Entities.Task;

namespace AngajatiWebApi.Contexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Timekeeping> Timekeepings { get; set; }

    }
}
