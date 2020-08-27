using System;
using System.Collections.Generic;
using System.Text;

namespace carsales.common.models
{
    public class VehicleDetails : Vehicle
    {
        public string[] Photos { get; set; }
        public Feature[] Features { get; set; }
    }
}
