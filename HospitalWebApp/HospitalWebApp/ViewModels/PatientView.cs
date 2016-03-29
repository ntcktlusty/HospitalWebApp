using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.ViewModels
{
    public class PatientView
    {
        public int ID { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Models.Station> Stations { get; set; }

        public virtual ICollection<Models.Order> Orders { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
