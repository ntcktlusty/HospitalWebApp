using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }

        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        public int MealID { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
