using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Meal
    {
        public int ID { get; set; }
        public string name { get; set; }
        [Display(Name = "Avaiable to")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime validTo { get; set; }
        [Display(Name = "Avaiable since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime validSince { get; set; }
        public int mealTypeID { get; set; }
        public virtual MealType mealType { get; set; }

        public virtual ICollection<Order> orders { get; set; }
    }
}