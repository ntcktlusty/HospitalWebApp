using System.Collections.Generic;

namespace HospitalWebApp.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public virtual ICollection<Station> Stations { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
