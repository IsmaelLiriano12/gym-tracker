using System;

namespace GymTrackerShared.Models
{
    public class ProgressiveOverload : PhysicalActivity
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public DateTime DateCreated { get; set; }

        public Exercise Exercise { get; set; }

    }
}
