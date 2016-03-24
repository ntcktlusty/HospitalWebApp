using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Patient
    {
        public int ID { get; set; }
        [Display(Name = "First name")]
        public string firstName { get; set; }
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        public virtual ICollection<Station> Stations { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
