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
        [Range(1, 7, ErrorMessage = "The number of days must be between 1 and 7")]
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