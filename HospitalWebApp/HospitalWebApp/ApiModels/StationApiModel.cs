using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalWebApp.ApiModels
{
    public class StationApiModel
    {
        public int ID { get; set; }

        public int Number { get; set; }

        public DateTime DueTo { get; set; }

        public int PatientID { get; set; }
    }
}