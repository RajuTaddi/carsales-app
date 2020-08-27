using carsales.common.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace carsales.infrastructure.interfaces
{
    public interface IRestClient
    {
        Task<List<Vehicle>> GetAsync();
        Task<VehicleDetails> GetByIdAsync(string id);
    }
}
