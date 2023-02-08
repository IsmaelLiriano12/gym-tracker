using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Models.WgerModels
{
    public class SuggestionsCollection
    {
        [JsonProperty("suggestions")]
        public IEnumerable<SuggestionsResult> Suggestions { get; set; }
    }
}
