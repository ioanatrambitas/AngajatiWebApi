using AngajatiWebApi.Contexts;
using AngajatiWebApi.Services.Repositories;
using System;

namespace AngajatiWebApi.Services.UnitsOfWork
{
    public class TaskUnitOfWork : ITaskUnitOfWork
    {
        private readonly EmployeeContext _context;

        public TaskUnitOfWork(EmployeeContext context, ITaskRepository tasks,
            ITrainingRepository trainings)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Tasks = tasks ?? throw new ArgumentNullException(nameof(context));
            Trainings = trainings ?? throw new ArgumentNullException(nameof(context));
        }

        public ITaskRepository Tasks { get; }


        public ITrainingRepository Trainings { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
