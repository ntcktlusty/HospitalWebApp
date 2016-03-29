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
using HospitalWebApp.ApiModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace HospitalWebApp.Controllers.Api
{
    public class MealsController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/Meals
        public IQueryable<MealApiModel> GetMeals()
        {
            return db.Meals.ProjectTo<MealApiModel>();
        }

        // GET: api/Meals/5
        [ResponseType(typeof(MealApiModel))]
        public IHttpActionResult GetMeal(int id)
        {
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<MealApiModel>(meal));
        }

        // PUT: api/Meals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeal(int id, MealApiModel mealApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mealApiModel.ID)
            {
                return BadRequest();
            }
            Meal meal = Mapper.Map<Meal>(mealApiModel);

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
        [ResponseType(typeof(MealApiModel))]
        public IHttpActionResult PostMeal(MealApiModel mealApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Meal meal = Mapper.Map<Meal>(mealApiModel);
            db.Meals.Add(meal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meal.ID }, Mapper.Map<MealApiModel>(meal));
        }

        // DELETE: api/Meals/5
        [ResponseType(typeof(MealApiModel))]
        public IHttpActionResult DeleteMeal(int id)
        {
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            db.Meals.Remove(meal);
            db.SaveChanges();

            return Ok(Mapper.Map<MealApiModel>(meal));
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