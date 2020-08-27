using carsales.common.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace carsales.core.interfaces
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();
        Task<VehicleDetails> GetVehicleById(string id);
    }
}
