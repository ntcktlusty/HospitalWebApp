using System;
using System.Collections.Generic;
using HospitalWebApp.Models;

namespace HospitalWebApp.Data_Access_Layer
{
    class MealInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<MealContext>
    {
        protected override void Seed(MealContext context)
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
        }
    }
}
