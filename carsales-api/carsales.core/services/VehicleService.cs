using carsales.common.models;
using carsales.core.interfaces;
using carsales.infrastructure.interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace carsales.core.services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRestClient _client;

        public VehicleService(IRestClient restClient)
        {
            _client = restClient;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await this._client.GetAsync();
        }

        public async Task<VehicleDetails> GetVehicleById(string id)
        {
            return await this._client.GetByIdAsync(id);
        }
    }
}
