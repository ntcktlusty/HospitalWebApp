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
    public class PatientsController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/Patients
        public IQueryable<PatientApiModel> GetPatients()
        {
            return db.Patients.ProjectTo<PatientApiModel>();
        }

        // GET: api/Patients/5
        [ResponseType(typeof(PatientApiModel))]
        public IHttpActionResult GetPatient(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map < PatientApiModel>(patient));
        }

        // PUT: api/Patients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(int id, PatientApiModel patientApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientApiModel.ID)
            {
                return BadRequest();
            }

            Patient patient = Mapper.Map<Patient>(patientApiModel);
            db.Entry(patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        [ResponseType(typeof(PatientApiModel))]
        public IHttpActionResult PostPatient(PatientApiModel patientApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Patient patient = Mapper.Map<Patient>(patientApiModel);
            db.Patients.Add(patient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patient.ID }, Mapper.Map<PatientApiModel>(patient));
        }

        // DELETE: api/Patients/5
        [ResponseType(typeof(PatientApiModel))]
        public IHttpActionResult DeletePatient(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patient);
            db.SaveChanges();

            return Ok(Mapper.Map<PatientApiModel>(patient));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(int id)
        {
            return db.Patients.Count(e => e.ID == id) > 0;
        }
    }
}