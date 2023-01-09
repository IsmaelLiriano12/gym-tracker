using GymTrackerShared.Models;
using GymTrackerShared.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTracker.ViewModels
{
    public class DashboardViewModel
    {
        private readonly ProfileData profileData;

        public DashboardViewModel(ProfileData profileData)
        {
            this.profileData = profileData;
        }

        public int MaintenanceCalories => profileData.GetMaintenanceCalories();
        public int CaloricDeficit => profileData.GetCaloricDeficit();
        public int CaloricSurplus => profileData.GetCaloricSurplus();
    }
}
