using GymTrackerShared.Models;
using System.Data.Entity;
using System.Linq;

namespace GymTrackerShared.Data
{
    public class ExerciseDaysRepository : Repository<ExerciseDay>
    {
        public ExerciseDaysRepository(Context context) 
            : base(context)
        {
        }

        public ExerciseDay Get(int id, int routineId, int dayId)
        {
            return Context.ExerciseDays
                .Include(e => e.Exercise)
                .Include(e => e.Routine)
                .Include(e => e.TrainingDay)
                .Where(e => e.ExerciseId == id && e.RoutineId == routineId && e.TrainingDayId == dayId)
                .SingleOrDefault();
        }
    }
}
