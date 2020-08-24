using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstVehicleApp.Models.Vehicles
{
    public class Make
    {
        [Key]
        [MaxLength(30)]
        public string Brand { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [DisplayName("Year")]
        public DateTime Circa { get; set; }

        [MaxLength(50)]
        public string CEO { get; set; }

        public List<CarModel> Models { get; set; }
    }
}