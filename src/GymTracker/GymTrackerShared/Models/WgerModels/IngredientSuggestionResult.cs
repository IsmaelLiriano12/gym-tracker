using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models.WgerModels
{
    public class IngredientSuggestionResult
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("data")]
        public IngredientDataSuggestionResult Data { get; set; }
    }

    public class IngredientDataSuggestionResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
