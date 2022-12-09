using GymTrackerShared.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Identity
{
    public class GymUserStore<T> : UserStore<IdentityUser> where T : IdentityUser
    {
        public GymUserStore(GymTrackerDbContext context) 
            : base(context)
        {
        }
    }
}
