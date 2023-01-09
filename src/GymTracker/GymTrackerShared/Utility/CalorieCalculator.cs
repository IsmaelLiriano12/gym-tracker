using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Utility
{
    public static class CalorieCalculator
    {
        private static Dictionary<ActivityLevel, double> activitylevels;
        static CalorieCalculator()
        {
            activitylevels = new Dictionary<ActivityLevel, double>
            {
                { ActivityLevel.Sedentary, 1.2 },
                { ActivityLevel.LightlyActive, 1.375 },
                { ActivityLevel.ModeratelyActive, 1.5 },
                { ActivityLevel.VeryActive, 1.675 },
                { ActivityLevel.ExtremelyActive, 1.8 },
            };
        }

        public static int GetCaloricDeficit(this ProfileData profileData)
        {
            return (int)(GetMaintenanceCalories(profileData) * 0.9);
        }        
        
        public static int GetCaloricSurplus(this ProfileData profileData)
        {
            var maintenanceCalories = GetMaintenanceCalories(profileData);

            return (int)(maintenanceCalories + (maintenanceCalories * 0.15));
        }

        public static int GetMaintenanceCalories(this ProfileData profileData)
        {
            return (int)(CalculateBasalMetabolicRate(profileData) * activitylevels[profileData.ActivityLevel]);
        }


        private static double CalculateBasalMetabolicRate(ProfileData profileData)
        {
            var BasalMetabolicRate = 0d;

            switch (profileData.Sex)
            {
                case Sex.Male:
                    BasalMetabolicRate = (10 * profileData.Weight) + (6.25 * profileData.Height) - (5 * profileData.Age) + 5;
                    break;
                case Sex.Female:
                    BasalMetabolicRate = (10 * profileData.Weight) + (6.25 * profileData.Height) - (5 * profileData.Age) - 161;
                    break;
            }

            return BasalMetabolicRate;
        }
    }
}
