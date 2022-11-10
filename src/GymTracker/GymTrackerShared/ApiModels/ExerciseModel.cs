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
    public class ExerciseModel
    {
        [Required]
        public int RoutineId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        [Range(1, 2000)]
        public decimal Weight { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required] 
        [Range(1, 10)]
        public int Sets { get; set; }
        public Routine.TrainingDay DayOfTraining { get; set; }
    }
}
