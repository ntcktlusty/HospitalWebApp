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
    public class OrdersController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/Orders
        public IQueryable<OrderApiModel> GetOrders()
        {
            return db.Orders.ProjectTo<OrderApiModel>();
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderApiModel))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<OrderApiModel>(order));
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, OrderApiModel orderApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderApiModel.ID)
            {
                return BadRequest();
            }
            Order order = Mapper.Map<Order>(orderApiModel);
            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(OrderApiModel))]
        public IHttpActionResult PostOrder(OrderApiModel orderApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = Mapper.Map<Order>(orderApiModel);
            db.Orders.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.ID }, Mapper.Map<OrderApiModel>(order));
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(OrderApiModel))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(Mapper.Map<OrderApiModel>(order));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.ID == id) > 0;
        }
    }
}