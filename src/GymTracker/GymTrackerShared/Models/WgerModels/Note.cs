using Newtonsoft.Json;

namespace GymTrackerShared.Models.WgerModels
{
    public class Note
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("exercise")]
        public int Exercise { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}