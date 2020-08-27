using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace carsales.common.models
{
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    public class Vehicle
    {
        //[JsonPropertyName("id")]
        public string Id { get; set; }

        //[JsonPropertyName("odometer")]
        public int Odometer { get; set; }

        //[JsonPropertyName("title")]
        public string Title { get; set; }

        //[JsonPropertyName("state")]
        public string State { get; set; }

        //[JsonPropertyName("price")]
        public decimal Price { get; set; }
        
        //[JsonPropertyName("photo")]
        public string Photo { get; set; }

        //[JsonPropertyName("sellerType")]
        public SellerType SellerType { get; set; }

        //[JsonPropertyName("listingType")]
        public ListingType ListingType { get; set; }
    }
}
