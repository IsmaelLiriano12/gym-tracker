using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models.WgerModels
{
    public class ExerciseSuggestionsResult
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("data")]
        public DataSuggestionResult Data { get; set; }
    }

    public class DataSuggestionResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("base_id")]
        public int BaseId { get; set; }
    }
}
