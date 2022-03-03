using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GymTrackerShared.Data
{
    public class RoutinesRepository
    {
        private Context _context = null;

        public RoutinesRepository(Context context)
        {
            _context = context;
        }

        public Routine Get(int id)
        {
            return _context.Routines
                .Include(r => r.ExerciseDays.Select(e => e.Exercise))
                .Include(r => r.ExerciseDays.Select(t => t.TrainingDay))
                .Where(r => r.Id == id)
                .SingleOrDefault();
        }
    }
}
