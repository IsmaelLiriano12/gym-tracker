using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTracker.Models
{
    public class MuscleGroup
    {
        public MuscleGroup()
        {
            Exercises = new List<Exercise>(); 
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ExerciseId { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}