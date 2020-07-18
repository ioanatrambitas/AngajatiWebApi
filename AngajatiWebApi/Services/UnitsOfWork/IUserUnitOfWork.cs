using AngajatiWebApi.Services.Repositories;
using System;

namespace AngajatiWebApi.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }

}
