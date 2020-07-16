using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AngajatiWebApi.Entities
{
    public class Timekeeping
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime Stop { get; set; }

        [Required]
        [MaxLength(150)]
        public string Place { get; set; }

        public bool? Deleted { get; set; } 

    }
}
