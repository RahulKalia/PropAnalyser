using PropertyAnalyser.Models;
using PropertyAnalyser.Models.AverageSoldPrices;
using PropertyAnalyser.Models.Listings;
using PropertyAnalyser.Options;
using PropertyAnalyser.Options.AverageSoldPriceOptions;
using PropertyAnalyser.Options.Listings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAnalyser
{
    class ZooplaDotNetClient
    {
        private string _accessToken = String.Empty;
        private ZooplaHttpClient _httpClient;

        public ZooplaDotNetClient(string token)
        {
            _accessToken = token;
            _httpClient = new ZooplaHttpClient();
        }

        public async Task<AverageAreaSoldPriceResponse> GetAverageAreaSoldPrice(StandardLocationParameters locationParams)
        {
            string url = Endpoints.AVERAGE_AREA_SOLD_PRICE + "?api_key=" + _accessToken;

            url += locationParams.GetUrlParams();

            return await _httpClient.GetObject<AverageAreaSoldPriceResponse>(url);
        }

        public Task<PropertyListingsResponse> GetPropertyListings(StandardLocationParameters locationParams, ListingBaseOptions options)
        {
            string url = Endpoints.PROPERTY_LISTINGS + "?api_key=" + _accessToken;

            url += locationParams.GetUrlParams();
            url += options.GetUrlParams();

            return _httpClient.GetObject<PropertyListingsResponse>(url);
        }
    }
}
