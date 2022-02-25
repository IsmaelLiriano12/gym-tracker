using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Models
{
    public class MuscleGroup
    {
        public MuscleGroup()
        {
            Exercises = new List<Exercise>(); 
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }
    }
}