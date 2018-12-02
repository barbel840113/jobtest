using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using BizCover.Repository.Cars.Entities;

namespace BizCover.Repository.Cars.CarDbContext
{
    public class CarDbContext : DbContext
    {
        public CarDbContext()
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
