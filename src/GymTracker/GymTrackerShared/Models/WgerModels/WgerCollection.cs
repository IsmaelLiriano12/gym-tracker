using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models.WgerModels
{
    public class WgerCollection<T>
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; }

        [JsonProperty(PropertyName = "next", Required = Required.AllowNull)]
        public string Next { get; set; }

        [JsonProperty(PropertyName = "previous", Required = Required.AllowNull)]
        public string Previous { get; set; }

        [JsonProperty(PropertyName = "results")]
        public T Results { get; set; }
    }
}
