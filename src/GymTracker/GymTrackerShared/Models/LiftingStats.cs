using System.ComponentModel.DataAnnotations;

namespace GymTrackerShared.Models
{
    public abstract class LiftingStats
    {
        [Required, Range(1, 2000)]
        public decimal Weight { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required, Range(1, 10)]
        public int Sets { get; set; }
    }
}