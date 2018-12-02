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

        public Task<double> CalculateDiscount(List<Car> cars)
        {
            double discount = 0.00f;
            discount = CalculateDiscountForCost(cars,discount);
            discount = CalculateDiscountNumberOfCars(cars, discount);
            discount = CalculateDiscountForYearOfCar(cars, discount);

            return Task.FromResult(discount);
        }

        private static double CalculateDiscountForCost(List<Car> cars,double discount)
        {
            var sum = cars.Sum(x => x.Price);         

            if (sum > 100000.00M)
            {
                discount += 5.00; // Return 5% discount
            }

           
            return discount;
        }

        private static double CalculateDiscountForYearOfCar(List<Car> cars, double discount)
        {
            // iterate through all cars and find model before 2000 and apply 10% for each.
            cars.ForEach(x =>
            {
                if (int.Parse(x.Model) < 2000)
                {
                    discount += 10.00;
                }
            });
            return discount;
        }

        private static double CalculateDiscountNumberOfCars(List<Car> cars, double discount)
        {
            if (cars.Count > 2)
            {
                discount += 3.00;// Return 3% discount
            }

            return discount;
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
