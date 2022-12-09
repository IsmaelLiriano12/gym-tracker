using GymTrackerShared.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTracker.ViewModels
{
    public class UserProfileViewModel
    {
        private readonly IdentityUser user;
        private readonly ProfileData profileData;

        public UserProfileViewModel(IdentityUser user, ProfileData profileData)
        {
            this.user = user;
            this.profileData = profileData;
        }

        public string Username => user.UserName;
        public ProfileData ProfileData => profileData;
    }
}
