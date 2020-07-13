using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngajatiWebApi.Entities
{
    public class Training
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(150)]
        public string TrainingName { get; set; }
        //durata cursului 
        [Required]
        public int Period { get; set; }
         
        [Required]
        public double Price { get; set; }

        public bool? Deleted { get; set; }

    }
}
