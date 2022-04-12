using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class ExercisesRepository : Repository<Exercise>
    {
        public ExercisesRepository(Context context)
            : base(context)
        {
        }

        public IList<Exercise> GetList()
        {
            return Context.Exercises
                .OrderBy(e => e.MuscleTrained)
                .ToList();
        }

        public Exercise Get(int id)
        {
            return Context.Exercises
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }
    }
}
