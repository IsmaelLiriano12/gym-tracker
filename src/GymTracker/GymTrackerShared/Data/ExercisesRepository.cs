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


        public Exercise Get(int id)
        {
            return Context.Exercises
                .Include(e => e.MuscleGroup)
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }
    }
}
