﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAnalyser.Models.Listings
{
    public class PropertyListingsResponse : ResponseModelBase
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }
        public double Longitude { get; set; }
        [JsonProperty("listing")]
        public List<Listing> Listings { get; set; }
        public double Latitude { get; set; }
    }
}
