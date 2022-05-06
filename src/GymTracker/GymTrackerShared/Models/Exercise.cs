using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymTrackerShared.Models
{
    public partial class Exercise : PhysicalActivity
    {
        public Exercise()
        {
            ProgressiveOverloads = new List<ProgressiveOverload>();
        }

        public int Id { get; set; }
        public int RoutineId { get; set; }

        [Required]
        public string Name { get; set; }

        public string DisplayName
        {
            get
            {
                return $"{Name} - {MuscleTrained}";
            }
        }
        [Display(Name = "Muscle Group")]
        public MuscleGroup MuscleTrained { get; set; }
        [Display(Name = "Training Day")]
        public Routine.TrainingDay DayOfTraining { get; set; }

        public Routine Routine { get; set; }
        public ICollection<ProgressiveOverload> ProgressiveOverloads { get; set; }

        public void AddProgress(ProgressiveOverload progress)
        {
            ProgressiveOverloads.Add(progress);
        }
    }
}