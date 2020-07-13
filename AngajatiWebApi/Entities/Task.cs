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

        [Required]
        public Guid TrainingId { get; set; }

        [ForeignKey("TrainingId")]
        public virtual Training Traing { get; set; }

        public bool? Deleted { get; set; }

    }
}
