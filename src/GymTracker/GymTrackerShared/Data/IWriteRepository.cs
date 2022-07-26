using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IWriteRepository<in T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
