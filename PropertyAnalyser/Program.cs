using PropertyAnalyser.Models;
using PropertyAnalyser.Models.Listings;
using PropertyAnalyser.Options;
using PropertyAnalyser.Options.Enums;
using PropertyAnalyser.Options.Listings;
using System;
using System.Collections;

namespace PropertyAnalyser
{
    class Program
    {
        static void Main()
        {
            ZooplaDotNetClient client = new ZooplaDotNetClient("kwtd8fs3eqbvyxnfhqtd84hp");
            StandardLocationParameters locationParameters = new StandardLocationParameters();
            Console.WriteLine("Enter in a postcode:");
            locationParameters.PostCode = Console.ReadLine();
            locationParameters.OutputType = OutputType.OUTCODE;
            locationParameters.AreaType = AreaType.POSTCODES;

            Console.WriteLine("Enter minimum number of beds: ");
            locationParameters.MinimumBeds = Convert.ToInt32(Console.ReadLine());

            ListingBaseOptions listingBaseOptions = new ListingBaseOptions
            {
                PageSize = 100,
                PageNumber = 1,
                OrderBy = OrderBy.AGE,
                ListingStatus = "sale"
            };

            Console.WriteLine("Enter the max price you are willing to pay:");
            int MaxPrice = Convert.ToInt32(Console.ReadLine());
            var listingResponse = client.GetPropertyListings(locationParameters, listingBaseOptions);
            int AverageCurrentMarketPrice = (int)CalculateAverageHouseValue(listingResponse.Result);
            CalculateUndervaluedHouses(listingResponse.Result, AverageCurrentMarketPrice, MaxPrice);
            Console.WriteLine(AverageCurrentMarketPrice);

        }

        public static void CalculateUndervaluedHouses(PropertyListingsResponse listingResponse, int AveragePrice, int MaxPrice)
        {
            var newList = new ArrayList();
            for(int i =0; i < listingResponse.Listings.Count; i++)
            {
                if ((listingResponse.Listings[i].Price < AveragePrice) && (listingResponse.Listings[i].Price <= MaxPrice))
                {
                    newList.Add(listingResponse.Listings[i].DetailsUrl);
                    Console.WriteLine(listingResponse.Listings[i].Price);
                    Console.WriteLine(listingResponse.Listings[i].DetailsUrl);
                }
            }
        }

        public static float CalculateAverageHouseValue(PropertyListingsResponse listingResponse)
        {
            float averagePrice = 0;
            int listingCount = listingResponse.Listings.Count;
            for (int i = 0; i < listingCount; i++)
            {
                averagePrice += listingResponse.Listings[i].Price;
            }
            averagePrice = averagePrice / listingCount;

            return averagePrice;
        }
    }
}
