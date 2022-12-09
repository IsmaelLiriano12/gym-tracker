using GymTrackerShared.Data;
using GymTrackerShared.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace GymTracker.Api
{
    [RoutePrefix("api/user")]
    public class UsersApiController : ApiController
    {
        private readonly GymUserManager<IdentityUser, string> userManager;
        private readonly IProfileDataRepository profileDataRepository;

        public UsersApiController(GymUserManager<IdentityUser, string> userManager, 
                                  IProfileDataRepository profileDataRepository)
        {
            this.userManager = userManager;
            this.profileDataRepository = profileDataRepository;
        }

        [Route("getId")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserId()
        {
            try
            {
                var username = User.Identity.Name;
                var identity = await userManager.FindByNameAsync(username);

                return Ok(identity.Id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
