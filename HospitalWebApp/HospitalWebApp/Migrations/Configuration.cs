namespace HospitalWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.MealTypes.AddOrUpdate(p => p.Name, new[]
            {
                new MealType { Name = "breakfast" },
                new MealType { Name = "secondBreakfast" },
                new MealType { Name = "supper" },
                new MealType { Name = "lunch" },
                new MealType { Name = "dinner" }
            });

            context.Patients.AddOrUpdate(p => new { p.FirstName, p.LastName }, new[]
            {
                new Patient {FirstName = "John", LastName = "Doe" },
                new Patient {FirstName = "Joe", LastName = "Smith" },
                new Patient {FirstName = "John", LastName = "Snow" }
            });

            context.SaveChanges();

            context.Meals.AddOrUpdate(p => new { p.Name, p.ValidSince, p.ValidTo, p.MealTypeID }, new[]
            {
                new Meal { Name = "frytki, karkówka, buraki", ValidSince = DateTime.Parse("2016-03-24"), ValidTo = DateTime.Parse("2016-03-30"), MealTypeID = 1 },
                new Meal { Name = "makaron, kurczak, surówki", ValidSince = DateTime.Parse("2016-03-25"), ValidTo = DateTime.Parse("2016-03-30"), MealTypeID = 2 },
                new Meal { Name = "ry¿, kurczak, surówki", ValidSince = DateTime.Parse("2016-03-24"), ValidTo = DateTime.Parse("2016-03-28"), MealTypeID = 3 },
                new Meal { Name = "kasza, gulasz", ValidSince = DateTime.Parse("2016-03-22"), ValidTo = DateTime.Parse("2016-03-25"), MealTypeID = 4 }
            });

            context.Stations.AddOrUpdate(p => new { p.DueTo, p.Number, p.PatientID }, new[]
            {
                new Station { DueTo = DateTime.Parse("2016-03-30"), PatientID = 1, Number = 107 },
                new Station { DueTo = DateTime.Parse("2016-03-30"), PatientID = 2, Number = 107 }
            });

            context.SaveChanges();

            context.Orders.AddOrUpdate(p => new { p.MealID, p.PatientID, p.OrderDate }, new[]
            {
                new Order { MealID = 1, PatientID = 2, OrderDate = DateTime.Parse("2016-03-24") },
                new Order { MealID = 2, PatientID = 1, OrderDate = DateTime.Parse("2016-03-24") },
                new Order { MealID = 1, PatientID = 2, OrderDate = DateTime.Parse("2016-03-25") },
                new Order { MealID = 3, PatientID = 1, OrderDate = DateTime.Parse("2016-03-25") }

            });

            context.SaveChanges();
        }
    }
}
