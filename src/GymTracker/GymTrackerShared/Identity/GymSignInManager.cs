using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Web;
using System.Web.WebPages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace GymTrackerShared.Identity
{
    public class GymSignInManager<TUser, TKey> : SignInManager<IdentityUser, string>
    {
        public GymSignInManager(GymUserManager<IdentityUser, string> userManager)
            : base(userManager, HttpContext.Current.GetOwinContext().Authentication)
        {
        }
    }
}
