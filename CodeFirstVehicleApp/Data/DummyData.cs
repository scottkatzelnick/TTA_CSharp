using CodeFirstVehicleApp.Models;
using CodeFirstVehicleApp.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstVehicleApp.Data
{
    public class DummyData
    {
        public static List<Make> GetMakes()
        {
            List<Make> makes = new List<Make>()
            {
                new Make()
                {
                    Brand = "Ford",
                    Address = "P.O. Box 6248, Dearborn, MI 48126, USA",
                    Circa = new DateTime(1903, 6, 16),
                    CEO = "Jim Hackett"
                },

                new Make()
                {
                    Brand = "Mercedes Benz",
                    Address = "One Mercedes-Benz Drive, Sandy Springs, GA 30328, USA",
                    Circa = new DateTime(1926, 6, 28),
                    CEO = "Dieter Zetsche"
                },

                new Make()
                {
                    Brand = "Ferrari",
                    Address = "Ferrari SpA, headquarters and factory: Via Abetone Inferiore n. 4, I-41053 Maranello (MO), Italy",
                    Circa = new DateTime(1939, 9, 13),
                    CEO = "Louis C. Camilleri"
                }
            };
            return makes;
        }

        public static List<CarModel> GetModels(VehiclesContext context)
        {
            List<CarModel> models = new List<CarModel>()
            {
                new CarModel
                {
                    ModelName = "Mustang",
                    Year = 1964,
                    Color = Color.White,
                    Brand = context.Makes.Find("Ford").Brand
                },

                new CarModel
                {
                    ModelName = "SL 65 AMG",
                    Year = 2018,
                    Color = Color.GunMetal,
                    Brand = context.Makes.Find("Mercedes Benz").Brand
                },

                new CarModel
                {
                    ModelName = "F12 Berlinetta",
                    Year = 2013,
                    Color = Color.DeepRed,
                    Brand = context.Makes.Find("Ferrari").Brand
                }
            };
            return models;
        }
    }
}