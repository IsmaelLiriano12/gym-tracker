using GymTrackerShared.ApiModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymTracker.ApiModels
{
    public class RoutineModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ExerciseStatsModel> Exercises { get; set; }
    }
}