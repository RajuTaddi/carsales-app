using carsales.common.exceptions;
using carsales.common.models;
using carsales.infrastructure.Config;
using carsales.infrastructure.interfaces;
using carsales.infrastructure.models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace carsales.infrastructure.services
{
    public class RestClient : IRestClient
    {
        private readonly ILogger<RestClient> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _client;
        private readonly VehicleApiOptions _options;

        public RestClient(
            ILogger<RestClient> logger,
            IHttpClientFactory factory, 
            IOptions<VehicleApiOptions> options)
        {
            _logger = logger;
            _clientFactory = factory;
            _options = options.Value;
        }
        public async Task<List<Vehicle>> GetAsync()
        {
            try
            {
                var client = this.getClient();
                var response = await client.GetAsync(this._options.Path.Vehicles);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException(response.ReasonPhrase, (int)response.StatusCode);
                }

                var content = await response.Content.ReadAsStringAsync();
                var apiResponseData = JsonSerializer.Deserialize<VehicleApiResponse>(content,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }); ;
                return apiResponseData.Items;
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                if (e.GetType() == typeof(ApiException))
                    throw e;

                throw new ApiException(e.Message, (int)HttpStatusCode.InternalServerError);
            }
            
        }

        public async Task<VehicleDetails> GetByIdAsync(string id)
        {
            try
            {
                var client = this.getClient();
                var response = await client.GetAsync(
                    this._options.Path.Vehicles + this._options.Path.VehicleDetails.Replace("{id}", id));

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException(response.ReasonPhrase, (int)response.StatusCode);
                }

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<VehicleDetails>(content,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                if (e.GetType() == typeof(ApiException))
                    throw e;

                throw new ApiException(e.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        private HttpClient getClient()
        {
            if (this._client == null)
            {
                var client = this._clientFactory.CreateClient();
                client.BaseAddress = new Uri( this._options.Host);
                var token = Convert.ToBase64String(Encoding.Default.GetBytes("carsales:U9pdTdYYV1CZMYl"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", token);

                this._client = client;
            }

            return this._client;
        }
    }
}
