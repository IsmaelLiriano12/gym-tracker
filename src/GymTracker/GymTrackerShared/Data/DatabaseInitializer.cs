using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GymTrackerShared.Models;
using static GymTrackerShared.Models.Exercise;
using static GymTrackerShared.Models.Routine;

namespace GymTrackerShared.Data
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            //var day1 = new TrainingDay() { Name = "Day 1" };
            //var day2 = new TrainingDay() { Name = "Day 2" };
            //var day3 = new TrainingDay() { Name = "Day 3" };
            //var day4 = new TrainingDay() { Name = "Day 4" };
            //var day5 = new TrainingDay() { Name = "Day 5" };
            //var day6 = new TrainingDay() { Name = "Day 6" };
            //var day7 = new TrainingDay() { Name = "Day 7" };

            //context.TrainingDays.Add(day1);
            //context.TrainingDays.Add(day2);
            //context.TrainingDays.Add(day3);
            //context.TrainingDays.Add(day4);
            //context.TrainingDays.Add(day5);
            //context.TrainingDays.Add(day6);
            //context.TrainingDays.Add(day7);

            var myRoutine = new Routine()
            {
                Name = "Upper-Lower",
                NumberOfDays = 4
            };

            var exercise1 = new Exercise()
            {
                Name = "Bench Press",
                MuscleTrained = MuscleGroup.Chest,
                Repetitions = 5,
                Weight = 100,
                Sets = 3,
                DayOfTraining = TrainingDay.First
            };

            var progress1 = new ProgressiveOverload()
            {
                DateCreated = DateTime.Now,
                Weight = exercise1.Weight,
                Repetitions = exercise1.Repetitions,
                Sets = exercise1.Sets
            };

            exercise1.AddProgress(progress1);

            var exercise2 = new Exercise()
            {
                Name = "Squat",
                MuscleTrained = MuscleGroup.Chest,
                Repetitions = 5,
                Weight = 100,
                Sets = 3,
                DayOfTraining = TrainingDay.Second
            };

            var progress2 = new ProgressiveOverload()
            {
                DateCreated = DateTime.Now,
                Weight = exercise1.Weight,
                Repetitions = exercise1.Repetitions,
                Sets = exercise1.Sets
            };

            exercise2.AddProgress(progress2);

            var exercise3 = new Exercise()
            {
                Name = "Row",
                MuscleTrained = MuscleGroup.Back,
                Repetitions = 5,
                Weight = 100,
                Sets = 3,
                DayOfTraining = TrainingDay.Third
            };

            var progress3 = new ProgressiveOverload()
            {
                DateCreated = DateTime.Now,
                Weight = exercise1.Weight,
                Repetitions = exercise1.Repetitions,
                Sets = exercise1.Sets
            };

            exercise3.AddProgress(progress3);

            var exercise4 = new Exercise()
            {
                Name = "Deadlift",
                MuscleTrained = MuscleGroup.Legs,
                Repetitions = 5,
                Weight = 100,
                Sets = 3,
                DayOfTraining = TrainingDay.Fourth
            };

            var progress4 = new ProgressiveOverload()
            {
                DateCreated = DateTime.Now,
                Weight = exercise1.Weight,
                Repetitions = exercise1.Repetitions,
                Sets = exercise1.Sets
            };

            exercise4.AddProgress(progress4);

            var exercise5 = new Exercise()
            {
                Name = "Sit ups",
                MuscleTrained = MuscleGroup.Abdomen,
                Repetitions = 5,
                Weight = 100,
                Sets = 3,
                DayOfTraining = TrainingDay.Fifth
            };

            var progress5 = new ProgressiveOverload()
            {
                DateCreated = DateTime.Now,
                Weight = exercise1.Weight,
                Repetitions = exercise1.Repetitions,
                Sets = exercise1.Sets
            };

            exercise5.AddProgress(progress5);

            var exercise6 = new Exercise()
            {
                Name = "Pull ups",
                MuscleTrained = MuscleGroup.Back,
                Repetitions = 5,
                Weight = 100,
                Sets = 3,
                DayOfTraining = TrainingDay.Sixth
            };

            var progress6 = new ProgressiveOverload()
            {
                DateCreated = DateTime.Now,
                Weight = exercise1.Weight,
                Repetitions = exercise1.Repetitions,
                Sets = exercise1.Sets
            };

            exercise6.AddProgress(progress6);

            var exercise7 = new Exercise()
            {
                Name = "Leg Press",
                MuscleTrained = MuscleGroup.Legs,
                Repetitions = 5,
                Weight = 100,
                Sets = 3,
                DayOfTraining = TrainingDay.Seventh
            };

            var progress7 = new ProgressiveOverload()
            {
                DateCreated = DateTime.Now,
                Weight = exercise1.Weight,
                Repetitions = exercise1.Repetitions,
                Sets = exercise1.Sets
            };

            exercise7.AddProgress(progress7);

            context.Exercises.Add(exercise1);
            context.Exercises.Add(exercise2);
            context.Exercises.Add(exercise3);
            context.Exercises.Add(exercise4);
            context.Exercises.Add(exercise5);
            context.Exercises.Add(exercise6);
            context.Exercises.Add(exercise7);




            
            myRoutine.AddExercise(exercise1);
            myRoutine.AddExercise(exercise2);
            myRoutine.AddExercise(exercise3);
            myRoutine.AddExercise(exercise4);

            context.Routines.Add(myRoutine);

            context.SaveChanges();
        }
    }
}