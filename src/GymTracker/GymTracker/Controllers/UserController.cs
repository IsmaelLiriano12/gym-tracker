using GymTracker.ViewModels;
using GymTrackerShared.Data;
using GymTrackerShared.Identity;
using GymTrackerShared.Models;
using Microsoft.AspNet.Identity;
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
        private readonly IAccountDataRepository accountDataRepository;

        public UserController(GymUserManager<IdentityUser, string> userManager, 
                              GymSignInManager<IdentityUser, string> signInManager,
                              IAccountDataRepository accountDataRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountDataRepository = accountDataRepository;
        }

        [Route("account")]
        public async Task<ActionResult> ManageAccountData(string id)
        {
            var accountData = await accountDataRepository.GetAccountDataAsync(User.Identity.GetUserId());

            var viewModel = new UserProfileViewModel(User.Identity.Name, accountData);

            return View(viewModel);
        }

        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("login")]
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

        [Route("register")]
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

                accountDataRepository.Add(profileData);

                await accountDataRepository.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }
    }
}
