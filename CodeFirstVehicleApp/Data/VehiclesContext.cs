using CodeFirstVehicleApp.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstVehicleApp.Data
{
    public class VehiclesContext : DbContext
    {
        public VehiclesContext() : base("DefaultConnection")
        { }

        public DbSet<Make> Makes { get; set; }
        public DbSet<CarModel> Car_Models { get; set; }
    }
}