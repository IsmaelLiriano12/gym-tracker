using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class MuscleGroupsRepository
    {
        private Context _context = null;
        public MuscleGroupsRepository(Context context) 
        { 
            _context = context;
        }

        public IList<MuscleGroup> GetList(bool includeExercises = true)
        {
            var muscleGroups = _context.MuscleGroups.AsQueryable();
            if (includeExercises)
            {
                muscleGroups.Include(m => m.Exercises);
            }
            return muscleGroups.OrderBy(m => m.Name).ToList();
        }

        public MuscleGroup Get(int id)
        {
            return _context.MuscleGroups
                .Where(m => m.Id == id)
                .SingleOrDefault();
        }

        public void AddExercise(int id, Exercise exercise)
        {
            var muscleGroup = Get(id);
            muscleGroup.AddExercise(exercise);
            _context.SaveChanges();
        }
    }
}
