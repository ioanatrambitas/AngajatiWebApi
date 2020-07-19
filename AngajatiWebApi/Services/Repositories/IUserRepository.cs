using AngajatiWebApi.Entities;
using System.Collections.Generic;

namespace AngajatiWebApi.Services.Repositories
{
   public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
