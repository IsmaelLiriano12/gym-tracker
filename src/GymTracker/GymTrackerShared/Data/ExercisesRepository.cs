using GymTrackerShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GymTrackerShared.Data
{
    public class ExercisesRepository : IExercisesRepository
    {
        private readonly GymTrackerDbContext context;

        public ExercisesRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Exercise> GetList()
        {
            return context.Exercises
                .OrderBy(e => e.MuscleTrained);
        }

        public IEnumerable<IGrouping<Routine.TrainingDay, Exercise>> GetGroupedExercises(int routineId)
        {
            var listOfExercises = context.Exercises
                .Where(e => e.RoutineId == routineId).ToList();

            return listOfExercises.GroupBy(e => e.DayOfTraining);
                
        }

        public Exercise Get(int id)
        {
            return context.Exercises
                .Include(e => e.ProgressiveOverloads)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Exercise exercise)
        {
            context.Set<Exercise>().Add(exercise);
            context.SaveChanges();
        }

        public void Update(Exercise exercise)
        {
            context.Entry(exercise).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var exercise = Get(id);
            context.Exercises.Remove(exercise);
            context.SaveChanges();
        }
    }
}
