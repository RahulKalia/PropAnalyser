using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAnalyser.Options.Listings
{
    public class PriceChangeSummary
    {
        public string Direction { get; set; }
        public string Percent { get; set; }
        [JsonProperty("last_updated_date")]
        public DateTime LastUpdatedDate { get; set; }
    }
}
