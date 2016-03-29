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

namespace HospitalWebApp.Controllers.Api
{
    public class MealTypesController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/MealTypes
        public IQueryable<MealTypeApiModel> GetMealTypes()
        {
            
            return db.MealTypes.Select(mealtype => new MealTypeApiModel { ID = mealtype.ID, Name = mealtype.Name });
            //return db.MealTypes.Select(mealtype => new { mealtype.ID, mealtype.Name });
        }

        // GET: api/MealTypes/5
        [ResponseType(typeof(MealType))]
        public IHttpActionResult GetMealType(int id)
        {
            MealType mealType = db.MealTypes.Find(id);
            if (mealType == null)
            {
                return NotFound();
            }

            return Ok(Global.mapper.Map<ViewModels.MealTypeView>(mealType));
        }

        // PUT: api/MealTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMealType(int id, MealType mealType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mealType.ID)
            {
                return BadRequest();
            }

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
        [ResponseType(typeof(MealType))]
        public IHttpActionResult PostMealType(MealType mealType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MealTypes.Add(mealType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mealType.ID }, mealType);
        }

        // DELETE: api/MealTypes/5
        [ResponseType(typeof(MealType))]
        public IHttpActionResult DeleteMealType(int id)
        {
            MealType mealType = db.MealTypes.Find(id);
            if (mealType == null)
            {
                return NotFound();
            }

            db.MealTypes.Remove(mealType);
            db.SaveChanges();

            return Ok(mealType);
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