using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngajatiWebApi.ExternalModels
{
    public class TrainingDTO
    {
        public Guid ID { get; set; }

        public string TrainingName { get; set; }

        public int Period { get; set; }

        public double Price { get; set; }

    }
}
