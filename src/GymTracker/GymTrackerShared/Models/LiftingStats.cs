using System.ComponentModel.DataAnnotations;

namespace GymTrackerShared.Models
{
    public abstract class LiftingStats
    {
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required]
        public int Sets { get; set; }
    }
}