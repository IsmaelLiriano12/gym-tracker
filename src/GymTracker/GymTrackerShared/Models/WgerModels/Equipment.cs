using Newtonsoft.Json;

namespace GymTrackerShared.Models.WgerModels
{
    public class Equipment
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}