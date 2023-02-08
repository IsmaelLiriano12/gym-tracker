using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models.WgerModels
{
    public class ExerciseBaseInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "category", Required = Required.AllowNull)]
        public Category Category { get; set; }

        [JsonProperty(PropertyName = "muscles", Required = Required.AllowNull)]
        public List<Muscle> Muscles { get; set; }

        [JsonProperty(PropertyName = "muscles_secondary", Required = Required.AllowNull)]
        public List<Muscle> MusclesSecondary { get; set; }

        [JsonProperty(PropertyName = "equipment", Required = Required.AllowNull)]
        public List<Equipment> Equipment { get; set; }

        [JsonProperty(PropertyName = "images", Required = Required.AllowNull)]
        public List<Image> Images { get; set; }

        [JsonProperty(PropertyName = "exercises", Required = Required.AllowNull)]
        public List<Exercise> Exercises { get; set; }

        [JsonProperty(PropertyName = "variations", Required = Required.AllowNull)]
        public int? Variations { get; set; }
       

    }
}
