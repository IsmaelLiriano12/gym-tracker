using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IRoutinesRepository : IWriteRepository<Routine>
    {
        Task<IEnumerable<Routine>> GetList(bool includeExercises);
        Task<Routine> Get(int id);
    }
}
