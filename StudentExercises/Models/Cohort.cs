using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercises.Models
{
    public class Cohort
    {
         
        public int Id { get; set; }
        [Required]
        [Display(Name = "cohort Name")]
        public string Name { get; set; }
    }
}
