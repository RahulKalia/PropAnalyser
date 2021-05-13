using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAnalyser.Options.Listings
{
    public class ImageAndDescription
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
