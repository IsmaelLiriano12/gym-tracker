using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GymTrackerShared.Models;
using static GymTrackerShared.Models.ExerciseStats;
using static GymTrackerShared.Models.Routine;
using System.Threading.Tasks;
using GymTrackerShared.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace GymTrackerShared.Data
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<GymTrackerDbContext>
    {
        protected override void Seed(GymTrackerDbContext context)
        {
            var userStore = new GymUserStore<IdentityUser>(context);
            var userManager = new GymUserManager<IdentityUser, string>(userStore);

            var identityResult = userManager.Create(new IdentityUser("ismaelgymtracker"), "Liriano15");

            var user = userManager.Find("ismaelgymtracker", "Liriano15");

            var accountData = new AccountData()
            {
                Weight = 66.2,
                Height = 185,
                Age = 21,
                ActivityLevel = ActivityLevel.ModeratelyActive,
                Sex = Sex.Male
            };

            accountData.UserId = user.Id;

            context.Accounts.Add(accountData);

            var myRoutine = new Routine()
            {
                Name = "Upper-Lower",
                UserId = user.Id
            };

            var exercise1 = new ExerciseStats()
            {
                ExerciseBaseId = 73,
                Name = "Bench Press",
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

            var exercise2 = new ExerciseStats()
            {
                ExerciseBaseId = 849,
                Name = "Squat",
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

            var exercise3 = new ExerciseStats()
            {
                ExerciseBaseId = 81,
                Name = "Bent Over Dumbbell Rows",
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

            var exercise4 = new ExerciseStats()
            {
                ExerciseBaseId = 630,
                Name = "Sumo Deadlift",
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