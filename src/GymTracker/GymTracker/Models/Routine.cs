using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTracker.Models
{
    public class Routine
    {
        public Routine()
        {
            Exercises = new List<Exercise>();
            ExerciseDays = new List<ExerciseDay>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrainingDaysId { get; set; }
        public int ExerciseId { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<ExerciseDay> ExerciseDays { get; set; }

        public void AddTrainingDaysAndExercises(Exercise exercise, TrainingDay trainingday)
        {
            ExerciseDays.Add(new ExerciseDay()
            {
                Exercise = exercise,
                TrainingDay = trainingday
            });
        }
    }
}