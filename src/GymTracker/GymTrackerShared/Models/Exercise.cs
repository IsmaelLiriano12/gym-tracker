using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            Routines = new List<ExerciseDay>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required, Range(1, 10)]
        public int Sets { get; set; }

        public string DisplayName
        {
            get
            {
                return $"{Name} - {MuscleTrained}";
            }
        }
        [Display(Name = "Muscle Group")]
        public MuscleGroup MuscleTrained { get; set; }

        public ICollection<ExerciseDay> Routines { get; set; }
    }
}