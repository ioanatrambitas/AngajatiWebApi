using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngajatiWebApi.Entities
{
    public class Task
    {
        [Key]
        public Guid ID {get; set; }

        [Required]
        [MaxLength(150)]
        public string TaskName { get; set; }

        [MaxLength(2500)]
        public string Details { get; set; }

        [Required]
        public Guid TrainingId { get; set; }

        [ForeignKey("TrainingId")]
        public virtual Training Training { get; set; }

        [Required]
        public double PayPerHour { get; set; }

        public bool? Deleted { get; set; }

    }
}
