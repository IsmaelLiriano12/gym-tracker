using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class ExercisesRepository
    {
        private Context _context = null;

        public ExercisesRepository(Context context)
        {
            _context = context;
        }

        public Exercise Get(int id)
        {
            return _context.Exercises
                .Include(e => e.MuscleGroup)
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }
    }
}
