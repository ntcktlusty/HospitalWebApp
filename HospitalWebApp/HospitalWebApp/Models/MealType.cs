using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class MealType
    {
        public enum TypeOfMeal
        {
            breakfast, secondBreakfast, lunch, dinner, supper
        }
        public int ID { get; set; }
        public TypeOfMeal type { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
