﻿using System;
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
    public class StationsController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/Stations
        public IQueryable<StationApiModel> GetStations()
        {
            return db.Stations.ProjectTo<StationApiModel>();
        }

        // GET: api/Stations/5
        [ResponseType(typeof(StationApiModel))]
        public IHttpActionResult GetStation(int id)
        {
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<StationApiModel>(station));
        }

        // PUT: api/Stations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStation(int id, StationApiModel stationApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stationApiModel.ID)
            {
                return BadRequest();
            }
            Station station = Mapper.Map<Station>(stationApiModel);
            db.Entry(station).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
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

        // POST: api/Stations
        [ResponseType(typeof(StationApiModel))]
        public IHttpActionResult PostStation(StationApiModel stationApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Station station = Mapper.Map<Station>(stationApiModel);
            db.Stations.Add(station);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = station.ID }, Mapper.Map<StationApiModel>(station));
        }

        // DELETE: api/Stations/5
        [ResponseType(typeof(StationApiModel))]
        public IHttpActionResult DeleteStation(int id)
        {
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return NotFound();
            }

            db.Stations.Remove(station);
            db.SaveChanges();

            return Ok(Mapper.Map<StationApiModel>(station));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationExists(int id)
        {
            return db.Stations.Count(e => e.ID == id) > 0;
        }
    }
}