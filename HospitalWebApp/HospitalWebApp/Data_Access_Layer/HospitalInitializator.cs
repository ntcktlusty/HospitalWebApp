using HospitalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWebApp.Data_Access_Layer
{
    class HospitalInitializator: System.Data.Entity.DropCreateDatabaseIfModelChanges<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {
            var mealTypes = new List<MealType>
            {
                new MealType { type="breakfast" },
                new MealType { type="secondBreakfast" },
                new MealType { type="supper" },
                new MealType { type="lunch" },
                new MealType { type="dinner" }
            };

            mealTypes.ForEach(s => context.MealTypes.Add(s));
            context.SaveChanges();

            var meals = new List<Meal>
            {
                new Meal { name="frytki, karkówka, buraki", validSince=DateTime.Parse("2016-03-24"), validTo=DateTime.Parse("2016-03-30"), mealTypeID=4 },
                new Meal { name="makaron, kurczak, surówki", validSince=DateTime.Parse("2016-03-25"), validTo=DateTime.Parse("2016-03-30"), mealTypeID=4 },
                new Meal { name="ryż, kurczak, surówki", validSince=DateTime.Parse("2016-03-24"), validTo=DateTime.Parse("2016-03-28"), mealTypeID = 4 },
                new Meal { name="kasza, gulasz", validSince=DateTime.Parse("2016-03-22"), validTo=DateTime.Parse("2016-03-25"), mealTypeID = 4 },
            };

            meals.ForEach(s => context.Meals.Add(s));
            context.SaveChanges();

            var patients = new List<Patient>
            {
                new Patient {firstName="John", lastName="Doe" },
                new Patient {firstName="Joe", lastName="Smith" },
                new Patient {firstName="John", lastName="Snow" }
            };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();

            var stations = new List<Station>
            {
                new Station { dueTo=DateTime.Parse("2016-03-30"), patientID=1, number=107 },
                new Station { dueTo=DateTime.Parse("2016-03-30"), patientID=2, number=107 }
            };

            stations.ForEach(s => context.Stations.Add(s));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order { mealID=1, patientID=2, orderDate=DateTime.Parse("2016-03-24") },
                new Order { mealID=2, patientID=1, orderDate=DateTime.Parse("2016-03-24") },
                new Order { mealID=1, patientID=2, orderDate=DateTime.Parse("2016-03-25") },
                new Order { mealID=3, patientID=1, orderDate=DateTime.Parse("2016-03-25") },

            };

            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
        }
    }
}
