using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models.WgerModels
{
    public class SuggestionsCollection<T>
    {
        [JsonProperty("suggestions")]
        public IEnumerable<T> Suggestions { get; set; }
    }
}
