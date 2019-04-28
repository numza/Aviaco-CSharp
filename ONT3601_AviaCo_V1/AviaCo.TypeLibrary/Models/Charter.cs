using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCo.TypeLibrary.Models
{
    public class Charter
    {
        public int CharterTripID { get; set; }
        public DateTime? CharterDate { get; set; }
        public string AircraftNumber { get; set; }
        public string CharterDestination { get; set; }
        public decimal? CharterDistance { get; set; }
        public decimal? CharterHoursFlown { get; set; }
        public decimal? CharterHoursWaited { get; set; }
        public decimal? CharterFuelUsage { get; set; }
        public int? CharterOilUsage { get; set; }
        public int? CustomerCode { get; set; }
        public int? PilotNumber { get; set; }
        public int? CoPilotNumber { get; set; }
    }
}
