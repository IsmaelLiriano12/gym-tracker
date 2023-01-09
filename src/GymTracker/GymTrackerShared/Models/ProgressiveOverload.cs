using System;

namespace GymTrackerShared.Models
{
    public class ProgressiveOverload : LiftingStats
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public DateTime DateCreated { get; set; }

        public string Date => DateCreated.ToShortDateString();

        public Exercise Exercise { get; set; }

    }
}
