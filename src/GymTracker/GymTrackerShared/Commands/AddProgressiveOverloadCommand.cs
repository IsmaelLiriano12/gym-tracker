using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Commands
{
    public class AddProgressiveOverloadCommand
    {
        private readonly Context _context;

        public AddProgressiveOverloadCommand(Context context)
        {
            this._context = context;
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

            _context.ProgressiveOverloads.Add(progress);
            _context.SaveChanges();

            return progress;
        }
    }
}
