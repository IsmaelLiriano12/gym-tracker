using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public abstract class Repository<TEntity>
        where TEntity : class
    {
        protected Context Context = null;

        public Repository(Context context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var set = Context.Set<TEntity>();
            var entity = set.Find(id);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
