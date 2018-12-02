using BizCover.Repository.Cars.Entities;
using BizCover.Repository.Cars.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace BizCover.Api.Cars.Controllers
{


    public class CarsController : ApiController
    {
        // Below is just the sample code from the Visual Studio Web Api Template. 
        // Feel free to replace this with whatever implementation you feel is suitable and production ready for a web api.

        // Calling the 3rd party api is expensive and its data only gets updated every 24 hours. Caching can help with this.

        // The repository BizCover.Repository.Cars can be found in ../packages/BizCover.Repository.Cars.1.0.0/BizCover.Repository.Cars.dll. You can restructure this solution as you like.

        private readonly CarRepository _carRepository;

        public CarsController(CarRepository carRepository)
        {
            this._carRepository = carRepository;
        }

        [Route("api/cars")]
        [HttpGet]
        // GET api/values
        public async Task<List<Car>> GetAllCars()
        {
            try
            {
                var allCars = await this._carRepository.GetAllCars();

                return allCars;
            }
            catch (Exception ex)
            {
                return new List<Car>();
            }
        }

        [Route("api/cars/getdiscount")]
        [HttpPost]
        public async Task<double> GetDiscount(List<Car> cars)
        {
            return await this._carRepository.CalculateDiscount(cars);

        }
    }
}
