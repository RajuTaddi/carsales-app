using carsales.common.models;
using carsales.core.services;
using carsales.infrastructure.interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace carsales.test
{
    [TestFixture]
    public class TestVehicleService
    {
        
        [Test]
        public void TestVehicleService_GetVehicles()
        {
            var vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle
            {
                Id = "1234"
            });

            var restClientMock = new Mock<IRestClient>();
            restClientMock.Setup(m => m.GetAsync()).Returns(Task.FromResult(vehicles));

            var vehicleService = new VehicleService(restClientMock.Object);
            var response = vehicleService.GetVehicles().Result;
            Assert.NotNull(response);
            Assert.AreEqual(response[0].Id, vehicles[0].Id);
        }

        [Test]
        public void TestVehicleService_GetVehicleById()
        {
            var vehicle = new VehicleDetails
            {
                Id = "1234"
            };

            var restClientMock = new Mock<IRestClient>();
            restClientMock.Setup(m => m.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(vehicle));

            var vehicleService = new VehicleService(restClientMock.Object);
            var response = vehicleService.GetVehicleById("1234").Result;
            Assert.NotNull(response);
            Assert.AreEqual(response.Id, vehicle.Id);
        }
    }
}