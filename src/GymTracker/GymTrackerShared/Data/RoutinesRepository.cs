using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GymTrackerShared.Data
{
    public class RoutinesRepository : IRoutinesRepository
    {
        private readonly GymTrackerDbContext context;

        public RoutinesRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Routine>> GetRoutinesAsync(bool includeExercises = false)
        {
            if(includeExercises == true)
            {
                return await context.Routines
                    .Include(r => r.Exercises)
                    .ToListAsync();
            }
            else
            {
                return await context.Routines
                    .ToListAsync();
            }
        }

        public async Task<Routine> GetAsync(string userId, bool includeExercises = false)
        {
            if (includeExercises == true)
            {
                return await context.Routines
                .Include(r => r.Exercises)
                .FirstOrDefaultAsync(r => r.UserId == userId);
            }
            else
            {
                return await context.Routines
                .FirstOrDefaultAsync(r => r.UserId == userId);
            }
            
        }

        public void Add(Routine routine)
        {
            context.Routines.Add(routine);
        }

        public void Update(Routine routine)
        {
            context.Entry(routine).State = EntityState.Modified;
        }

        public void Delete(Routine routine)
        {
            context.Routines.Remove(routine);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
