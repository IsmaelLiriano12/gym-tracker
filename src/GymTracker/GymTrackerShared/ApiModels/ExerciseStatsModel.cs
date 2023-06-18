using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GymTrackerShared.ApiModels
{
    public class ExerciseStatsModel
    {
        [Required]
        public string Name { get; set; }

        [Required] 
        public decimal Weight { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required] 
        public int Sets { get; set; }
        [Required]
        public Routine.TrainingDay DayOfTraining { get; set; }
    }
}
