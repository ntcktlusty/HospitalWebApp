using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Station
    {
        public int ID { get; set; }
        public int number { get; set; }
        [Display(Name = "In station till")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dueTo { get; set; }
        public int patientID { get; set; }
        public virtual Patient patient { get; set; }
    }
}
