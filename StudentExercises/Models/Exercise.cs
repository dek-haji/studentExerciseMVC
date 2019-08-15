using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace StudentExercises.Models
{
    public class Exercise
    {
        [Display(Name = "Exercise Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Exercise Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Language")]
        public string Language { get; set; }

    }
}
