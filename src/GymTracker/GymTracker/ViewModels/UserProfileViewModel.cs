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
        private readonly string userName;
        private readonly AccountData profileData;


        public UserProfileViewModel(string userName, AccountData profileData)
        {
            this.userName = userName;
            this.profileData = profileData;
        }

        public string Username => userName;
        public AccountData ProfileData => profileData;
    }
}
