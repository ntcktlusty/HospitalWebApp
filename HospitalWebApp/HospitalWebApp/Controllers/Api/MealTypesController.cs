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
    public class MealTypesController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/MealTypes
        public IQueryable<MealTypeApiModel> GetMealTypes()
        {
            return db.MealTypes.ProjectTo<MealTypeApiModel>();
        }

        // GET: api/MealTypes/5
        [ResponseType(typeof(MealTypeApiModel))]
        public IHttpActionResult GetMealType(int id)
        {
            MealType mealType = db.MealTypes.Find(id);
            if (mealType == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<MealTypeApiModel>(mealType));
        }

        // PUT: api/MealTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMealType(int id, MealTypeApiModel mealTypeApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mealTypeApiModel.ID)
            {
                return BadRequest();
            }
            MealType mealType = Mapper.Map<MealType>(mealTypeApiModel);
            db.Entry(mealType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealTypeExists(id))
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

        // POST: api/MealTypes
        [ResponseType(typeof(MealTypeApiModel))]
        public IHttpActionResult PostMealType(MealTypeApiModel mealTypeApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MealType mealType = Mapper.Map<MealType>(mealTypeApiModel);
            db.MealTypes.Add(mealType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mealType.ID }, Mapper.Map<MealTypeApiModel>(mealType));
        }

        // DELETE: api/MealTypes/5
        [ResponseType(typeof(MealTypeApiModel))]
        public IHttpActionResult DeleteMealType(int id)
        {
            MealType mealType = db.MealTypes.Find(id);
            if (mealType == null)
            {
                return NotFound();
            }

            db.MealTypes.Remove(mealType);
            db.SaveChanges();

            return Ok(Mapper.Map<MealTypeApiModel>(mealType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MealTypeExists(int id)
        {
            return db.MealTypes.Count(e => e.ID == id) > 0;
        }
    }
}