﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GymTracker.Models;

namespace GymTracker.Data
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

            var chest = new MuscleGroup() { Name = "Chest" };
            var back = new MuscleGroup() { Name = "Back" };
            var shoulders = new MuscleGroup() { Name = "Shoulders" };
            var abdomen = new MuscleGroup() { Name = "Abdomen" };
            var legs = new MuscleGroup() { Name = "Legs" };

            context.MuscleGroups.Add(chest);
            context.MuscleGroups.Add(back);
            context.MuscleGroups.Add(shoulders);
            context.MuscleGroups.Add(abdomen);
            context.MuscleGroups.Add(legs);

            var exercise1 = new Exercise()
            {
                Name = "Press de Banca",
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };
            exercise1.AddMuscleGroup(chest);

            var exercise2 = new Exercise()
            {
                Name = "Sentadilla",
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };
            exercise1.AddMuscleGroup(legs);

            var exercise3 = new Exercise()
            { 
                Name = "Remo",
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };
            exercise1.AddMuscleGroup(back);

            var exercise4 = new Exercise()
            {
                Name = "Peso Muerto",
                Repetitions = 5,
                Weight = 100,
                Sets = 3
            };
            exercise1.AddMuscleGroup(legs);

            var myRoutine = new Routine()
            {
                Name = "Torso Pierna"
            };
            myRoutine.AddTrainingDaysAndExercises(exercise1, day1);
            myRoutine.AddTrainingDaysAndExercises(exercise2, day2);
            myRoutine.AddTrainingDaysAndExercises(exercise3, day3);
            myRoutine.AddTrainingDaysAndExercises(exercise4, day4);

            context.Routines.Add(myRoutine);

            context.SaveChanges();
        }
    }
}