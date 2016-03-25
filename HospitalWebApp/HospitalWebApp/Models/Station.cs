using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApp.Models
{
    public class Station
    {
        public int ID { get; set; }
        
        public int Number { get; set; }

        [Display(Name = "In station till")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueTo { get; set; }

        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
