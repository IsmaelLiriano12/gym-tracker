using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class ExerciseDaysRepository : Repository<ExerciseDay>
    {
        public ExerciseDaysRepository(Context context) 
            : base(context)
        {
        }

    }
}
