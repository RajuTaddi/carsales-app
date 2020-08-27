using System;
using System.Collections.Generic;
using System.Text;

namespace carsales.infrastructure.Config
{
    public class VehicleApiOptions
    {
        public const string VehicleApi = "VehicleApi";
        public string Host { get; set; }
        public PathConfig Path { get; set; }
    }

    public class PathConfig
    {
        public string Vehicles { get; set; }
        public string VehicleDetails { get; set; }
    }
}
