using System.Collections.Generic;
using System.Web.Http;

namespace BizCover.Api.Cars.Controllers
{
    public class CarsController : ApiController
    {
        // Below is just the sample code from the Visual Studio Web Api Template. 
        // Feel free to replace this with whatever implementation you feel is suitable and production ready for a web api.

        // Calling the 3rd party api is expensive and its data only gets updated every 24 hours. Caching can help with this.

        // The repository BizCover.Repository.Cars can be found in ../packages/BizCover.Repository.Cars.1.0.0/BizCover.Repository.Cars.dll. You can restructure this solution as you like.

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
