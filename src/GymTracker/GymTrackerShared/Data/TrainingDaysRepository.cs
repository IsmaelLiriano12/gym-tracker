using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class TrainingDaysRepository : Repository<TrainingDaysRepository>
    {
        public TrainingDaysRepository(Context context) 
            : base(context)
        {
        }

        public IList<TrainingDay> GetList()
        {
            return Context.TrainingDays.ToList();
        }

        public IList<TrainingDay> GetList(int trainingDayId)
        {
            return Context.TrainingDays
                .Where(t => t.Id == trainingDayId)
                .ToList();
        }

        public TrainingDay Get(int id)
        {
            return Context.TrainingDays
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }
    }
}
