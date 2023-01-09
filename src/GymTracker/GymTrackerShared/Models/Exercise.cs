using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymTrackerShared.Models
{
    public partial class Exercise : LiftingStats
    {

        public Exercise()
        {
            ProgressiveOverloads = new List<ProgressiveOverload>();
        }

        public int Id { get; set; }
        public int RoutineId { get; set; }

        [Required]
        public string Name { get; set; }

        public string DisplayName => Name.ToUpper();

        public ProgressiveOverload CurrentProgress => ProgressiveOverloads
                    .LastOrDefault();

        public ProgressiveOverload LastPastMonthProgress
        {
            get
            {
                var progress = ProgressiveOverloads
                        .Where(p => p.DateCreated.Month == DateTime.Now.Month - 1)
                        .LastOrDefault();

                if (progress == null)
                {
                    progress = new ProgressiveOverload()
                    {
                        Weight = 0,
                        Repetitions = 0,
                        Sets = 0
                    };
                }

                return progress;
            }
        }

        [Display(Name = "Training Day")]
        public Routine.TrainingDay DayOfTraining { get; set; }

        public Routine Routine { get; set; }
        public ICollection<ProgressiveOverload> ProgressiveOverloads { get; set; }


        public void AddProgress(ProgressiveOverload progress) => ProgressiveOverloads.Add(progress);
       
    }
}