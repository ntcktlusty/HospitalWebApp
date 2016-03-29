using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.ViewModels
{
    public class OrderView
    {
        public int ID { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public int PatientID { get; set; }
        public virtual Models.Patient Patient { get; set; }

        public int MealID { get; set; }
        public virtual Models.Meal Meal { get; set; }
    }
}
