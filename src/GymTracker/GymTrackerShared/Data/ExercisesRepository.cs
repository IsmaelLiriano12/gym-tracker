using GymTrackerShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class ExercisesRepository : IExercisesRepository
    {
        private readonly GymTrackerDbContext context;

        public ExercisesRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await context.Exercises.ToListAsync();
        }

        public async Task<IEnumerable<IGrouping<Routine.TrainingDay, Exercise>>> GetGroupedExercises(int routineId)
        {
            var listOfExercises = await context.Exercises
                .Where(e => e.RoutineId == routineId).ToListAsync();

            return listOfExercises.OrderBy(e => e.DayOfTraining).GroupBy(e => e.DayOfTraining);
                
        }

        public async Task<Exercise> GetAsync(int id)
        {
            return await context.Exercises
                .Include(e => e.ProgressiveOverloads)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Add(Exercise exercise)
        {
            context.Exercises.Add(exercise);
        }

        public void Update(Exercise exercise)
        {
            context.Entry(exercise).State = EntityState.Modified;
        }

        public void Delete(Exercise exercise)
        {
            context.Exercises.Remove(exercise);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
