using GymTrackerShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GymTrackerShared.Data
{
    public class ExercisesStatsRepository : IExercisesStatsRepository
    {
        private readonly GymTrackerDbContext context;

        public ExercisesStatsRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ExerciseStats>> GetExercisesAsync()
        {
            return await context.Exercises.ToListAsync();
        }

        public async Task<IEnumerable<IGrouping<Routine.TrainingDay, ExerciseStats>>> GetGroupedExercises(int routineId)
        {
            var listOfExercises = await context.Exercises
                .Where(e => e.RoutineId == routineId).ToListAsync();

            return listOfExercises.OrderBy(e => e.DayOfTraining).GroupBy(e => e.DayOfTraining);
        }

        public async Task<ExerciseStats> GetAsync(int id)
        {
            return await context.Exercises
                .Include(e => e.ProgressiveOverloads)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Add(ExerciseStats exercise)
        {
            context.Exercises.Add(exercise);
        }

        public void Update(ExerciseStats exercise)
        {
            context.Entry(exercise).State = EntityState.Modified;
        }

        public void Delete(ExerciseStats exercise)
        {
            context.Exercises.Remove(exercise);
        }

        public async Task<bool> SaveChangesAsync()
        {
            context.Database.Log = message => Debug.WriteLine(message);

            var rowsSaved = await context.SaveChangesAsync();

            return rowsSaved > 0;
        }
    }
}
