using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class ProgressiveOverloadRepository : IProgressiveOverloadRepository
    {
        private readonly GymTrackerDbContext context;

        public ProgressiveOverloadRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProgressiveOverload>> GetProgressiveOverloads(int exerciseId)
        {
            var progresses = await context.ProgressiveOverloads
                .Where(p => p.ExerciseId == exerciseId && p.DateCreated.Year == DateTime.Today.Year)
                .ToListAsync();

            return GetLastProgressesForEachMonth(progresses);
        }

        private IEnumerable<ProgressiveOverload> GetLastProgressesForEachMonth(List<ProgressiveOverload> progressiveOverloads)
        {
            if(progressiveOverloads.Count == 0)
            {
                return progressiveOverloads;
            }

            List<ProgressiveOverload> lastProgresses = new List<ProgressiveOverload>();

            int currentMonth = progressiveOverloads[0].DateCreated.Month;

            for (int i = 0; i < progressiveOverloads.Count - 1; i++)
            {
                if (progressiveOverloads[i + 1].DateCreated.Month > currentMonth)
                {
                    currentMonth = progressiveOverloads[i + 1].DateCreated.Month;
                    lastProgresses.Add(progressiveOverloads[i]);
                }
            }
            lastProgresses.Add(progressiveOverloads.Last());

            return lastProgresses;
        }

        public async Task<ProgressiveOverload> AddAndSaveAsync(ExerciseStats exercise)
        {
            var progress = new ProgressiveOverload()
            {
                ExerciseId = exercise.Id,
                DateCreated = DateTime.Now,
                Weight = exercise.Weight,
                Repetitions = exercise.Repetitions,
                Sets = exercise.Sets
            };

            context.ProgressiveOverloads.Add(progress);
            await context.SaveChangesAsync();

            return progress;
        }
    }
}
