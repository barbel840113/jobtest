using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BizCover.Repository.Cars.Entities;


namespace BizCover.Repository.Cars.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCars();

        Task Update(Car car);

        Task<int> Add(Car newCar);
    }
}
