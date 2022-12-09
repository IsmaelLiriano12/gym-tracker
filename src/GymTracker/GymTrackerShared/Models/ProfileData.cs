using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public decimal Weight { get; set; }
        [Required]
        [Display(Name = "Height")]
        public double HeightInCentimeters { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Sex Sex { get; set; }

        public IdentityUser User { get; set; }
    }
}
