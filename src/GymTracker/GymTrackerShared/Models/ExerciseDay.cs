using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTrackerShared.Models
{
    /// <summary>
    /// Defines a many-to-many relationship between routines, exercises, and training days.
    /// </summary>
    public class ExerciseDay
    {

        public int Id { get; set; }
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public int TrainingDayId { get; set; }

        public Routine Routine { get; set; }
        public Exercise Exercise { get; set; }
        public TrainingDay TrainingDay { get; set; }
    }
}