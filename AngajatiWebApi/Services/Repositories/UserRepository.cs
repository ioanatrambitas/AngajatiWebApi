using AngajatiWebApi.Contexts;
using AngajatiWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;




namespace AngajatiWebApi.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly EmployeeContext _context;

        public UserRepository(EmployeeContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}
