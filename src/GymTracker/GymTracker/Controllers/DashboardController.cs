using GymTracker.ViewModels;
using GymTrackerShared.Data;
using GymTrackerShared.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly GymUserManager<IdentityUser, string> userManager;
        private readonly IProfileDataRepository profileDataRepository;

        public DashboardController(GymUserManager<IdentityUser, string> userManager,
                                   IProfileDataRepository profileDataRepository)
        {
            this.userManager = userManager;
            this.profileDataRepository = profileDataRepository;
        }

        public async Task<ActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var profileData = await profileDataRepository.GetProfileDataAsync(user.Id);


            return View(new DashboardViewModel(profileData));
        }
    }
}