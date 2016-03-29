using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Meal
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime ValidSince { get; set; }
        public int MealTypeID { get; set; }
        public virtual MealType MealType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}