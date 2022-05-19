using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Models
{
    public partial class Routine
    {
        public Routine()
        {
            Exercises = new List<Exercise>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }
    }
}