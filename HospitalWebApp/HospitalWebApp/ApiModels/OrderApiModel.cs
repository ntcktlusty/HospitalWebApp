using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalWebApp.ApiModels
{
    public class OrderApiModel
    {
        public int ID { get; set; }

        public DateTime OrderDate { get; set; }

        public int PatientID { get; set; }

        public int MealID { get; set; }
    }
}