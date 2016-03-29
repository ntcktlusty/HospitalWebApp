using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HospitalWebApp.Models;
using HospitalWebApp.ViewModels;

namespace HospitalWebApp.Controllers.Api
{
    public class MealsController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/Meals
        public IQueryable<dynamic> GetMeals()
        {
            return db.Meals.Select(meal => new { meal.ID, meal.Name, meal.ValidSince, meal.ValidTo, meal.MealTypeID });
        }

        // GET: api/Meals/5
        [ResponseType(typeof(Meal))]
        public IHttpActionResult GetMeal(int id)
        {
            Meal meal = db.Meals.Find(id);

            if (meal == null)
            {
                return NotFound();
            }

            return Ok(Global.mapper.Map<MealView>(meal));
        }

        // PUT: api/Meals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeal(int id, MealView mealView)
        {
            Meal meal = Global.mapper.Map<Meal>(mealView);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meal.ID)
            {
                return BadRequest();
            }

            db.Entry(meal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Meals
        [ResponseType(typeof(Meal))]
        public IHttpActionResult PostMeal(Meal meal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Meals.Add(meal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meal.ID }, meal);
        }

        // DELETE: api/Meals/5
        [ResponseType(typeof(Meal))]
        public IHttpActionResult DeleteMeal(int id)
        {
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            db.Meals.Remove(meal);
            db.SaveChanges();

            return Ok(meal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MealExists(int id)
        {
            return db.Meals.Count(e => e.ID == id) > 0;
        }
    }
}