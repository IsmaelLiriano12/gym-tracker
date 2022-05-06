using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using static GymTrackerShared.Models.Exercise;

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

        public SelectList MuscleGroups { get; set; }
        public SelectList TrainingDaysListItems { get; set; }

        public void Init(Context context, int trainingDayId)
        {
            //TrainingDaysListItems = new SelectList(
            //    new GetTrainingDayListQuery(context).Execute(trainingDayId),
            //    "Id", "Name");

            //MuscleGroups = new SelectList(Enum.GetValues(typeof(MuscleGroup)).Cast<MuscleGroup>()
            //    .Select(m => new SelectListItem
            //    {
            //        Text = m.ToString(),
            //        Value = ((int)m).ToString()
            //    }).ToList(), "Value", "Text");
        }
    }
}