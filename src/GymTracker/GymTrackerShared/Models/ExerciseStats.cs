using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymTrackerShared.Models
{
    public partial class ExerciseStats : LiftingStats
    {

        public ExerciseStats()
        {
            ProgressiveOverloads = new List<ProgressiveOverload>();
        }

        public int Id { get; set; }
        public int RoutineId { get; set; }
        public int ExerciseBaseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string DisplayName => Name.ToUpper();

        [Display(Name = "Training Day")]
        public Routine.TrainingDay DayOfTraining { get; set; }

        public Routine Routine { get; set; }
        public ICollection<ProgressiveOverload> ProgressiveOverloads { get; set; }


        public void AddProgress(ProgressiveOverload progress) => ProgressiveOverloads.Add(progress);
       
    }
}