using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GymTrackerShared.Data
{
    public class RoutinesRepository : Repository<Routine>
    {
        public RoutinesRepository(Context context)
            : base(context)
        {
        }

        public IList<Routine> GetList()
        {
            return Context.Routines
                .ToList();
        }

        public Routine Get(int id)
        {
            return Context.Routines
                .Include(r => r.ExerciseDays.Select(e => e.Exercise))
                .Include(r => r.ExerciseDays.Select(t => t.TrainingDay))
                .Where(r => r.Id == id)
                .SingleOrDefault();
        }
    }
}
