using AngajatiWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = AngajatiWebApi.Entities.Task;

namespace AngajatiWebApi.Contexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { 
        }
        public DbSet<User> User { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Timekeeping> Timekeepings { get; set; }

    }
}
