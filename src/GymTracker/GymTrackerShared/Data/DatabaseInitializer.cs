using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GymTrackerShared.Models;
using static GymTrackerShared.Models.Exercise;

namespace GymTrackerShared.Data
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var day1 = new TrainingDay() { Name = "Day 1" };
            var day2 = new TrainingDay() { Name = "Day 2" };
            var day3 = new TrainingDay() { Name = "Day 3" };
            var day4 = new TrainingDay() { Name = "Day 4" };
            var day5 = new TrainingDay() { Name = "Day 5" };
            var day6 = new TrainingDay() { Name = "Day 6" };
            var day7 = new TrainingDay() { Name = "Day 7" };

            context.TrainingDays.Add(day1);
            context.TrainingDays.Add(day2);
            context.TrainingDays.Add(day3);
            context.TrainingDays.Add(day4);
            context.TrainingDays.Add(day5);
            context.TrainingDays.Add(day6);
            context.TrainingDays.Add(day7);

            var exercise1 = new Exercise()
            {
                Name = "Bench Press",
                MuscleTrained = MuscleGroup.Chest,
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };

            var exercise2 = new Exercise()
            {
                Name = "Squat",
                MuscleTrained = MuscleGroup.Chest,
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };

            var exercise3 = new Exercise()
            {
                Name = "Row",
                MuscleTrained = MuscleGroup.Back,
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };

            var exercise4 = new Exercise()
            {
                Name = "Deadlift",
                MuscleTrained = MuscleGroup.Legs,
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };

            var exercise5 = new Exercise()
            {
                Name = "Sit ups",
                MuscleTrained = MuscleGroup.Abdomen,
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };

            var exercise6 = new Exercise()
            {
                Name = "Pull ups",
                MuscleTrained = MuscleGroup.Back,
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };

            var exercise7 = new Exercise()
            {
                Name = "Leg Press",
                MuscleTrained = MuscleGroup.Legs,
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };

            context.Exercises.Add(exercise1);
            context.Exercises.Add(exercise2);
            context.Exercises.Add(exercise3);
            context.Exercises.Add(exercise4);
            context.Exercises.Add(exercise5);
            context.Exercises.Add(exercise6);
            context.Exercises.Add(exercise7);

            var myRoutine = new Routine()
            {
                Name = "Upper-Lower",
                NumberOfDays = 4
            };
            myRoutine.AddExerciseAndDay(exercise1, day1);
            myRoutine.AddExerciseAndDay(exercise2, day2);
            myRoutine.AddExerciseAndDay(exercise3, day3);
            myRoutine.AddExerciseAndDay(exercise4, day4);

            context.Routines.Add(myRoutine);

            context.SaveChanges();
        }
    }
}