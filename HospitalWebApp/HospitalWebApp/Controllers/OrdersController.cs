using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalWebApp.Data_Access_Layer;
using HospitalWebApp.Models;

namespace HospitalWebApp.Controllers
{
    public class OrdersController : Controller
    {
        private MealContext db = new MealContext();

        //Get: /Orders
        public ActionResult Index()
        {
            return View(db.Orders);
        }

        //GET: /Orders/Add
        public ActionResult Create()
        {
            return View();
        }
    }
}