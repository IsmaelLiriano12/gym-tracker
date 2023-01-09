using GymTrackerShared.Utility;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models
{
    public class ProfileData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Sex Sex { get; set; }
        [Required]
        [Display(Name = "Activity")]
        public ActivityLevel ActivityLevel { get; set; }

        public IdentityUser User { get; set; }
        
    }
}
