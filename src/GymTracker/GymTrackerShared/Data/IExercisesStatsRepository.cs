using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IExercisesStatsRepository : IWriteRepository<ExerciseStats>
    {
        Task<IEnumerable<ExerciseStats>> GetExercisesAsync();
        Task<IEnumerable<IGrouping<Routine.TrainingDay, ExerciseStats>>> GetGroupedExercises(int routineId);
        Task<ExerciseStats> GetAsync(int id);
    }
}
