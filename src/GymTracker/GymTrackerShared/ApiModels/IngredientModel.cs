using GymTrackerShared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.ApiModels
{
    public class IngredientModel
    {
        [JsonProperty("wgerNutritionResultId")]
        public int WgerNutritionResultId { get; set; }
        [JsonProperty("meal")]
        public Meal Meal { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
