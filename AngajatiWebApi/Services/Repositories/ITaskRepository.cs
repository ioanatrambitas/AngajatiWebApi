using AngajatiWebApi.Entities;
using System;


namespace AngajatiWebApi.Services.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        Task GetTaskDetails(Guid taskId);

    }
}
