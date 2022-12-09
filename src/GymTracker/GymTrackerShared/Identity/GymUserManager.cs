using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Identity
{
    public class GymUserManager<TUser, TKey> : UserManager<IdentityUser, string> where TUser : IdentityUser
    {
        public GymUserManager(IUserStore<IdentityUser> userStore)
            : base(userStore)
        {
        }
    }
}
