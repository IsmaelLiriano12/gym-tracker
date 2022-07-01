using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IExercisesRepository : IWriteRepository<Exercise>
    {
        IEnumerable<Exercise> GetList();
        IEnumerable<IGrouping<Routine.TrainingDay, Exercise>> GetGroupedExercises(int routineId);
        Exercise Get(int id);
    }
}
