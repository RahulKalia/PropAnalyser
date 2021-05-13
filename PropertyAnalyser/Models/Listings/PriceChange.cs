using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAnalyser.Models.Listings
{
    public class PriceChange
    {
        public string Direction { get; set; }
        public DateTime Date { get; set; }
        public string Percent { get; set; }
        public int Price { get; set; }
    }
}
