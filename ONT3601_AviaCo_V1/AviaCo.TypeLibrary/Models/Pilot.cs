using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCo.TypeLibrary.Models
{
    public class Pilot
    {
        public int EmployeeID { get; set; }
        public string LicenseType { get; set; }
        public string PilotRatings { get; set; }
        public char? MedicalType { get; set; }
        public DateTime LastMedicalDate { get; set; }
        public DateTime LastPT135Date { get; set; }
    }
}
