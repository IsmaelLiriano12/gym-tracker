using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Models
{
    public class Exercise
    {
        public Exercise()
        {
            Routines = new List<ExerciseDay>();
        }

        public int Id { get; set; }
        public int MuscleGroupId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required]
        public int Sets { get; set; }

        public MuscleGroup MuscleGroup { get; set; }
        public ICollection<ExerciseDay> Routines { get; set; }

    }
}