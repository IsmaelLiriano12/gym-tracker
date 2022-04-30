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
            Routines = new List<ExerciseDay>();
        }

        public int Id { get; set; }

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

        public ICollection<ProgressiveOverload> ProgressiveOverloads { get; set; }
        public ICollection<ExerciseDay> Routines { get; set; }


        public void AddProgress(ProgressiveOverload progress)
        {
            ProgressiveOverloads.Add(progress);
        }
    }
}