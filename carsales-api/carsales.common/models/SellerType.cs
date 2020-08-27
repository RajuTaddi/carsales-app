using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace carsales.common.models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SellerType
    {
        [EnumMember(Value = "Dealer")]
        Dealer,

        [EnumMember(Value = "Private")]
        Private
    }
}
