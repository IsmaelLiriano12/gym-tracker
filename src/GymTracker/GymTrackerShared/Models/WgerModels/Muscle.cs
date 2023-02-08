using Newtonsoft.Json;

namespace GymTrackerShared.Models.WgerModels
{
    public class Muscle
    { 
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }
    }
}