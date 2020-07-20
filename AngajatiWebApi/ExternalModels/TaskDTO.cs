using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngajatiWebApi.ExternalModels
{
    public class TaskDTO
    {
        public Guid ID { get; set; }

        public string TaskName { get; set; }

        public string Details { get; set; }

        public Guid TrainingId { get; set; }

        public TrainingDTO Training { get; set; }

        public double PayPerHour { get; set; }

    }
}
