using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Models
{
    public class Routine
    {
        public Routine()
        {
            ExerciseDays = new List<ExerciseDay>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Days"), Required]
        public int NumberOfDays { get; set; }
        public ICollection<ExerciseDay> ExerciseDays { get; set; }

        public void AddExerciseAndDay(Exercise exercise, TrainingDay trainingDay)
        {
            ExerciseDays.Add(new ExerciseDay()
            {
                Exercise = exercise,
                TrainingDay = trainingDay
            });
        }
    }
}