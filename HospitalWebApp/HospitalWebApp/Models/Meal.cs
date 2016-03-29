﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Meal
    {
        public int ID { get; set; }
        
        public string Name { get; set; }

        [Display(Name = "Avaiable to")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Avaiable since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ValidSince { get; set; }

        public int MealTypeID { get; set; }
        public virtual MealType MealType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}