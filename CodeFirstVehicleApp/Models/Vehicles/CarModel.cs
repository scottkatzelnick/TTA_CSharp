using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CodeFirstVehicleApp.Models.Vehicles
{
    public class CarModel
    {
        public int CarModelId { get; set; }

        [DisplayName("Model")]
        public string ModelName { get; set; }

        public int Year { get; set; }
        public Color Color { get; set; }

        public string Brand { get; set; }
        public Make Make { get; set; }
    }
}