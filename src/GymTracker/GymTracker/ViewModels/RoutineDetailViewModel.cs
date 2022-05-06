using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTracker.ViewModels
{
    public class RoutineDetailViewModel
    {
       
        public Routine Routine { get; set; }

        public IEnumerable<IGrouping<Routine.TrainingDay, Exercise>> Exercises { get; set; }


        public void Init(Context context, int routineId) 
        {
            Exercises = new ExercisesRepository(context).GetGroupedExercises(routineId);
        }
    }
}