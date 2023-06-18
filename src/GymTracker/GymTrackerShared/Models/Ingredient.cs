using GymTrackerShared.Models.WgerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int NutritionFactsId { get; set; }
        public string Name { get; set; }
        public NutritionFacts NutritionFacts { get; set; }
        public Meal Meal { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
