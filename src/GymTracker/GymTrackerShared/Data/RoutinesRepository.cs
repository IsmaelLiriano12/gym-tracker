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

        public async Task<IEnumerable<Routine>> GetList()
        {
            return await context.Routines
                .Include(r => r.Exercises)
                .ToListAsync();
        }

        public async Task<Routine> Get(int id)
        {
            return await context.Routines
                .Include(r => r.Exercises)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task Add(Routine routine)
        {
            context.Routines.Add(routine);
            await context.SaveChangesAsync();
        }

        public async Task Update(Routine routine)
        {
            context.Entry(routine).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var routine = await Get(id);
            context.Routines.Remove(routine);
            await context.SaveChangesAsync();
        }
    }
}
