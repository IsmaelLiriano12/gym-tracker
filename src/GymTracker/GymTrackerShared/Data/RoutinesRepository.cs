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

        public IEnumerable<Routine> GetList()
        {
            return context.Routines
                .Include(r => r.Exercises);
        }

        public Routine Get(int id)
        {
            return context.Routines
                .Include(r => r.Exercises)
                .FirstOrDefault(r => r.Id == id);
        }
        public void Add(Routine routine)
        {
            context.Set<Routine>().Add(routine);
            context.SaveChanges();
        }

        public void Update(Routine routine)
        {
            context.Entry(routine).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var routine = Get(id);
            context.Routines.Remove(routine);
            context.SaveChanges();
        }
    }
}
