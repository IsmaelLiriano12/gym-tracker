using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.ViewModels
{
    public class ExerciseDaysAddViewModel
    {

        public int RoutineId
        {
            get { return Routine.Id; }
            set { Routine.Id = value; }
        }

        public Routine Routine { get; set; } = new Routine(); 
        
        public Exercise Exercise { get; set; }
        [Display(Name = "Training Day")]
        public int TrainingDayId { get; set; }
        [Display(Name = "Muscle Group")]
        public int MuscleGroupId { get; set; }

        public SelectList MuscleGroupListItems { get; set; }
        public SelectList TrainingDaysListItems { get; set; }

        public void Init(Context context, MuscleGroupsRepository muscleGroupsRepository,TrainingDaysRepository trainingDaysRepository ,int trainingDayId)
        {
            TrainingDaysListItems = new SelectList(
                trainingDaysRepository.GetList(trainingDayId),
                "Id", "Name");

            MuscleGroupListItems = new SelectList(
                muscleGroupsRepository.GetList(includeExercises: false),
                "Id", "Name");
        }
    }
}