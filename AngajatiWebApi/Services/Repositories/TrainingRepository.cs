using AngajatiWebApi.Contexts;
using AngajatiWebApi.Entities;
using AngajatiWebApi.Services.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngajatiWebApi.Services.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        private readonly EmployeeContext _context;

        public TrainingRepository(EmployeeContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
