using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public abstract class BaseRepository<TEntity>
    {
        protected Context Context = null;

        public BaseRepository(Context context)
        {
            Context = context;
        }
    }
}
