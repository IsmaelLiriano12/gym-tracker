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

        public async Task<IEnumerable<Exercise>> GetList()
        {
            return await context.Exercises.ToListAsync();
        }

        public async Task<IEnumerable<IGrouping<Routine.TrainingDay, Exercise>>> GetGroupedExercises(int routineId)
        {
            var listOfExercises = await context.Exercises
                .Where(e => e.RoutineId == routineId).ToListAsync();

            return listOfExercises.GroupBy(e => e.DayOfTraining);
                
        }

        public async Task<Exercise> Get(int id)
        {
            return await context.Exercises
                .Include(e => e.ProgressiveOverloads)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Add(Exercise exercise)
        {
            context.Exercises.Add(exercise);
            await context.SaveChangesAsync();
        }

        public async Task Update(Exercise exercise)
        {
            context.Entry(exercise).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exercise = await Get(id);
            context.Exercises.Remove(exercise);
            await context.SaveChangesAsync();
        }
    }
}
