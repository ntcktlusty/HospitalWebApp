﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class MealType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
