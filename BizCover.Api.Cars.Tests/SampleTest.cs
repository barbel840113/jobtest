using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using BizCover.Repository.Cars.Services;
using BizCover.ApplicationCore.Interfaces;
using BizCover.ApplicationCore.Services;
using BizCover.ApplicationCore.Logging;
using BizCover.Repository.Cars.Entities;
using System.Data.Entity;
using BizCover.Repository.Cars.CarDbContext;

namespace BizCover.Api.Cars.Tests
{
    [TestFixture]
    public class CarRepositoryTests
    {
        protected CarRepository _CarRepository;

        [SetUp]
        public void SetUp()
        {
            IAppLogger<Car> appLoger = new LoginAdapter<Car>();
            var dbContext = new Moq.Mock<CarDbContext>();
            IRepository<Car> carRepository = new EfRepostiory<Car>(dbContext.Object);
            IAsyncRepository<Car> carRepositoryAsync = new EfRepostiory<Car>(dbContext.Object);
            _CarRepository = new CarRepository(carRepositoryAsync,carRepository,appLoger);
        }

        public class GetAllCarsTests : CarRepositoryTests
        {
            [Test]
            public async Task ReturnsMoreThanOneValue_WhenGetAllData()
            {
                // Arrange + Act
                var cars = await _CarRepository.GetAllCars();

                // Assert
                Assert.True(cars.Count > 0);
            }
        }

        public class UpdateTests : CarRepositoryTests
        {
            private Car _testCar;

            public UpdateTests()
            {
                _testCar = new Car
                {
                    Id = 2,
                    Make = "Audi",
                    Model = "A3",
                    Year = 2018,
                    CountryManufactured = "Germany",
                    Colour = "Red",
                    Price = 90000M
                };
            }

            [Test]
            public async Task DataSourceUpdatedCorrectly_WhenValidCarUpdated()
            {
                // Arrange + Act
                await _CarRepository.Update(_testCar).ConfigureAwait(false);

                var allCars = _CarRepository.GetAllCars().Result;
                var updatedCar = allCars.FirstOrDefault(x => x.Id == 2);

                // Assert
                Assert.AreEqual("Red", updatedCar?.Colour);
                Assert.AreEqual(2018, updatedCar?.Year);
                Assert.AreEqual(90000M, updatedCar?.Price);
            }

            [Test]
            public void ThrowsException_WhenNoMakeProvided()
            {
                // Arrange
                _testCar.Make = null;

                // Act + Assert
                Assert.ThrowsAsync<Exception>(async () => await _CarRepository.Update(_testCar).ConfigureAwait(false));
            }

            [Test]
            public void ThrowsException_WhenNoModelProvided()
            {
                // Arrange
                _testCar.Model = null;

                // Act + Assert
                Assert.ThrowsAsync<Exception>(async () => await _CarRepository.Update(_testCar).ConfigureAwait(false));
            }

            [Test]
            public void ThrowsException_WhenInvalidYearProvided()
            {
                // Arrange
                var newCar = new Car
                {
                    Id = 2,
                    Make = "Benz",
                    Model = "xyz",
                    Year = 1850,
                    CountryManufactured = "Germany",
                    Colour = "Red"
                };

                // Act + Assert
                Assert.ThrowsAsync<Exception>(async () => await _CarRepository.Update(newCar).ConfigureAwait(false));
            }

            [Test]
            public void ThrowsException_WhenNoCountryProvided()
            {
                // Arrange
                _testCar.CountryManufactured = null;

                // Act + Assert
                Assert.ThrowsAsync<Exception>(async () => await _CarRepository.Update(_testCar).ConfigureAwait(false));
            }

            [Test]
            public void ThrowsException_WhenNoColourProvided()
            {
                // Arrange
                _testCar.Colour = null;

                // Act + Assert
                Assert.ThrowsAsync<Exception>(async () => await _CarRepository.Update(_testCar).ConfigureAwait(false));
            }

            [Test]
            public void ThrowsException_WhenPriceIsZero()
            {
                // Arrange
                _testCar.Price = 0M;

                // Act + Assert
                Assert.ThrowsAsync<Exception>(async () => await _CarRepository.Update(_testCar).ConfigureAwait(false));
            }
        }

        public class AddTests : CarRepositoryTests
        {
            [Test]
            public async Task NewCarAdded_WhenValidCarProvided()
            {
                // Arrange
                var newCar = new Car
                {
                    Make = "Alfa Romeo",
                    Model = "Stelvio",
                    Year = 2018,
                    CountryManufactured = "Italy",
                    Colour = "Red",
                    Price = 95000M
                };

                // Act
                var newId = await _CarRepository.Add(newCar).ConfigureAwait(false);

                var allCars = _CarRepository.GetAllCars().Result;
                var updatedCar = allCars.FirstOrDefault(x => x.Id == newId);

                // Assert
                Assert.AreEqual("Alfa Romeo", updatedCar?.Make);
                Assert.AreEqual("Stelvio", updatedCar?.Model);
                Assert.AreEqual(2018, updatedCar?.Year);
                Assert.AreEqual("Italy", updatedCar?.CountryManufactured);
                Assert.AreEqual("Red", updatedCar?.Colour);
                Assert.AreEqual(95000M, updatedCar?.Price);
            }
        }
    }
}
