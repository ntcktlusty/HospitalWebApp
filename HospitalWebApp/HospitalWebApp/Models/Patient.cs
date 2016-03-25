using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Patient
    {
        public int ID { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Station> Stations { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
