using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IReadRepository<T>
    {
        IEnumerable<T> GetList();
        T Get(int id);
    }
}
