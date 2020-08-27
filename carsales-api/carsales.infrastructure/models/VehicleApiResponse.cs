using carsales.common.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace carsales.infrastructure.models
{
    public class VehicleApiResponse
    {
        public List<Vehicle> Items { get; set; }
    }
}
