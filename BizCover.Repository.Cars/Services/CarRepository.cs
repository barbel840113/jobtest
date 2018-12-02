using System;
using System.Collections.Generic;
using System.Text;
using BizCover.Repository.Cars.Interfaces;
using BizCover.ApplicationCore.Interfaces;
using BizCover.Repository.Cars.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace BizCover.Repository.Cars.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly IAsyncRepository<Car> _carRepositoryAsync;
        private readonly IAppLogger<Car> _carLogger;
        private readonly IRepository<Car> _carRepository;

        public CarRepository(IAsyncRepository<Car> carRepositoryAsync,
            IRepository<Car> repositoryCar,
            IAppLogger<Car> logger)
        {
            this._carRepository = repositoryCar;
            this._carLogger = logger;
            this._carRepositoryAsync = carRepositoryAsync;
        }

        public Task<int> Add(Car newCar)
        {
            this._carRepository.Add(newCar);

            return Task.FromResult(newCar.Id);
        }

        public Task<List<Car>> GetAllCars()
        {
            return Task.FromResult(this._carRepository.ListAll().ToList<Car>());
        }

        public Task Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
