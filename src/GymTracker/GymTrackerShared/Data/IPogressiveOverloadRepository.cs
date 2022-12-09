using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IPogressiveOverloadRepository
    {
        Task<IEnumerable<ProgressiveOverload>> GetProgressiveOverloads(int exerciseId);
        Task<ProgressiveOverload> AddAndSaveAsync(Exercise exercise);
    }
}
