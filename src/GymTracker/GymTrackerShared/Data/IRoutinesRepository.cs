using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IRoutinesRepository
    {
        IEnumerable<Routine> GetList();
        Routine Get(int id);
        void Add(Routine routine);
        void Update(Routine routine);
        void Delete(int id);
    }
}
