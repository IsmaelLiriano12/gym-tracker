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
        private readonly IExercisesRepository exercisesRepository;

        public RoutineDetailViewModel(IExercisesRepository exercisesRepository)
        {
            this.exercisesRepository = exercisesRepository;
        }
        public Routine Routine { get; set; }

        public IEnumerable<IGrouping<Routine.TrainingDay, Exercise>> Exercises { get; set; }


        public void Init(int routineId) 
        {
            Exercises = exercisesRepository.GetGroupedExercises(routineId);
        }
    }
}