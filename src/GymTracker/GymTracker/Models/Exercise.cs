using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymTracker.Models
{
    public class Exercise
    {
        public Exercise()
        {
            Routines = new List<Routine>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required]
        public int Sets { get; set; }
        public int MuscleGroupId { get; set; }
        public int RoutineId { get; set; }

        public MuscleGroup MuscleGroup { get; set; }
        public ICollection<Routine> Routines { get; set; }

        public void AddMuscleGroup(MuscleGroup muscleGroup)
        {
            MuscleGroup = muscleGroup;
        }
    }
}