using GymTrackerShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GymTrackerShared.Data
{
    public class ExercisesRepository : Repository<Exercise>
    {
        public ExercisesRepository(Context context)
            : base(context)
        {
        }

        public IList<Exercise> GetList()
        {
            return Context.Exercises
                .OrderBy(e => e.MuscleTrained)
                .ToList();
        }

        public IEnumerable<IGrouping<Routine.TrainingDay, Exercise>> GetGroupedExercises(int routineId)
        {
            var listOfExercises = Context.Exercises
                .Where(e => e.RoutineId == routineId).ToList();

            return listOfExercises.GroupBy(e => e.DayOfTraining);
                
        }

        public Exercise Get(int id, int routineId)
        {
            return Context.Exercises
                .Include(e => e.ProgressiveOverloads)
                .FirstOrDefault(e => e.Id == id && e.RoutineId == routineId);
        }
    }
}
