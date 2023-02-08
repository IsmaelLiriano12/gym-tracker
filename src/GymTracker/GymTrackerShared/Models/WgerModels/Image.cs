using Newtonsoft.Json;

namespace GymTrackerShared.Models.WgerModels
{
    public class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("exercise_base")]
        public int ExerciseBase { get; set; }

        [JsonProperty("image")]
        public string ImageUrl { get; set; }
    }
}