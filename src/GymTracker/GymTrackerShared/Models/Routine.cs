using Microsoft.AspNet.Identity.EntityFramework;
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
            Exercises = new List<ExerciseStats>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ExerciseStats> Exercises { get; set; }
        public IdentityUser User { get; set; }

        public void AddExercise(ExerciseStats exercise)
        {
            Exercises.Add(exercise);
        }
    }
}