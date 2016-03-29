using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Station
    {
        public int ID { get; set; }
        
        public int Number { get; set; }
        public DateTime DueTo { get; set; }
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
