namespace CodeFirstVehicleApp.Migrations.Vehicles
{
    using CodeFirstVehicleApp.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstVehicleApp.Data.VehiclesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Vehicles";
        }

        protected override void Seed(CodeFirstVehicleApp.Data.VehiclesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Makes.AddOrUpdate(
                m => m.Brand, DummyData.GetMakes().ToArray());

            context.SaveChanges();

            context.Car_Models.AddOrUpdate(
                md => new { md.Brand, md.ModelName }, DummyData.GetModels(context).ToArray());
        }
    }
}