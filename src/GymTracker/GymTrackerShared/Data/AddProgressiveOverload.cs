using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class AddProgressiveOverload
    {
        private readonly GymTrackerDbContext context;

        public AddProgressiveOverload(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public ProgressiveOverload Execute(int exerciseId, decimal weight, int reps, int sets)
        {
            var progress = new ProgressiveOverload()
            {
                ExerciseId = exerciseId,
                DateCreated = DateTime.Now,
                Weight = weight,
                Repetitions = reps,
                Sets = sets
            };

            context.ProgressiveOverloads.Add(progress);
            context.SaveChanges();

            return progress;
        }
    }
}
