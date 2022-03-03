using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
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