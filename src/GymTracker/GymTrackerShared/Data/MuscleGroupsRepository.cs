using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class MuscleGroupsRepository : BaseRepository<MuscleGroupsRepository>
    {
        public MuscleGroupsRepository(Context context) 
            : base(context)
        {
        }

        public IList<MuscleGroup> GetList()
        {
            return Context.MuscleGroups
                .Include(m => m.Exercises)
                .ToList();
        }
    }
}
