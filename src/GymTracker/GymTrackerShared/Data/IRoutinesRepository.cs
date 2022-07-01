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
        IEnumerable<Routine> GetList();
        Routine Get(int id);
    }
}
