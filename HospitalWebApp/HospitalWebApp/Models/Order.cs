using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int patientID { get; set; }
        public int mealID { get; set; }
        [Display(Name = "Order date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime orderDate { get; set; }

        [Display(Name = "Patient")]
        public virtual Patient patient { get; set; }
        [Display(Name = "Meal")]
        public virtual Meal meal { get; set; }
    }
}
