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

            var myRoutine = new Routine()
            {
                Name = "Upper-Lower"
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
                DateCreated = new DateTime(2022, 5, 25, 12, 30, 5 ),
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
            
            myRoutine.AddExercise(exercise1);
            myRoutine.AddExercise(exercise2);
            myRoutine.AddExercise(exercise3);
            myRoutine.AddExercise(exercise4);

            context.Routines.Add(myRoutine);

            context.SaveChanges();
        }
    }
}