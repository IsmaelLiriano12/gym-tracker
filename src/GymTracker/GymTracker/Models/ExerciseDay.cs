using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymTracker.Models
{
    public class ExerciseDay
    {

        public int Id { get; set; }
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public int TrainingDaysId { get; set; }

        public Routine Routine { get; set; }
        public Exercise Exercise { get; set; }
        public TrainingDay TrainingDay { get; set; }
    }
}