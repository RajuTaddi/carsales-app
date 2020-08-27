using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace carsales.common.models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ListingType
    {
        [EnumMember(Value = "Used")]
        Used,

        [EnumMember(Value = "Demo")]
        Demo
    }
}
