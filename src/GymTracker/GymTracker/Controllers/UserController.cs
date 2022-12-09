using GymTracker.ViewModels;
using GymTrackerShared.Data;
using GymTrackerShared.Identity;
using GymTrackerShared.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        private readonly GymUserManager<IdentityUser, string> userManager;
        private readonly GymSignInManager<IdentityUser, string> signInManager;
        private readonly IProfileDataRepository profileDataRepository;

        public UserController(GymUserManager<IdentityUser, string> userManager, 
                              GymSignInManager<IdentityUser, string> signInManager,
                              IProfileDataRepository profileDataRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.profileDataRepository = profileDataRepository;
        }

        [Route("profile/{id}")]
        public async Task<ActionResult> ManageProfileData(string id)
        {
            var identity = await userManager.FindByIdAsync(id);
            if (identity == null) return HttpNotFound();

            var profileData = await profileDataRepository.GetProfileData(identity.Id);

            var viewModel = new UserProfileViewModel(identity, profileData);

            return View(viewModel);
        }

        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var signInStatus = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

            switch (signInStatus)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Dashboard");
                default:
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var identityResult = await userManager.CreateAsync(new IdentityUser(model.Username), model.Password);

            if (identityResult.Succeeded)
            {
                var profileData = model.ProfileData;
                var user = await userManager.FindAsync(model.Username, model.Password);

                profileData.UserId = user.Id;

                profileDataRepository.Add(profileData);

                await profileDataRepository.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }
    }
}
