using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IAddProgressiveOverload
    {
        ProgressiveOverload Execute(int exerciseId, decimal weight, int reps, int sets);
    }
}
