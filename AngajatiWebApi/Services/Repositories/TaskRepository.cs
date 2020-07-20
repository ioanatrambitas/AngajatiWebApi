using AngajatiWebApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace AngajatiWebApi.Services.Repositories
{
    public class TaskRepository : Repository<Entities.Task>, ITaskRepository
    {
        private readonly EmployeeContext _context;

        public TaskRepository(EmployeeContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public Entities.Task GetTaskDetails(Guid taskId)
        {
            return _context.Tasks
    .Where(b => b.ID == taskId && (b.Deleted == false || b.Deleted == null)).Include(b => b.Training)
                .FirstOrDefault();
        }

       
    } 
}
