﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BizCover.Repository.Cars.Entities
{
    /// <summary>
    /// Car Model
    /// </summary>
    public class Car
    {
        
        public int Id{ get; set; }

        public string Make { get; set; }

        public string Model{ get; set; }

        public int Year{ get; set; }
        public string CountryManufactured { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }

    }
}
