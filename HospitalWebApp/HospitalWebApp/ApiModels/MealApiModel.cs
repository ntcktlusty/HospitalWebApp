using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalWebApp.ApiModels
{
    public class MealApiModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime ValidSince { get; set; }

        public int MealTypeID { get; set; }
    }
}