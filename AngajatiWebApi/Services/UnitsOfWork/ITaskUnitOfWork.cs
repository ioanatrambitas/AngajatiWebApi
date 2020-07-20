using AngajatiWebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngajatiWebApi.Services.UnitsOfWork
{
    public interface ITaskUnitOfWork : IDisposable
    {
        ITaskRepository Tasks { get; }

        ITrainingRepository Trainings { get; }

        int Complete();
    }
}
