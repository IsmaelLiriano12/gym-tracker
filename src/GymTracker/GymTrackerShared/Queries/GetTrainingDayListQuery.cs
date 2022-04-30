using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Queries
{
    public class GetTrainingDayListQuery
    {
        private readonly Context _context;

        public GetTrainingDayListQuery(Context context)
        {
            this._context = context;
        }

        public IList<TrainingDay> Execute(int trainingDayId)
        {
            return _context.TrainingDays
                .Where(t => t.Id == trainingDayId)
                .ToList();
        }
    }
}
