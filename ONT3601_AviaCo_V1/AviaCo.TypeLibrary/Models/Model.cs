using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCo.TypeLibrary.Models
{
    public class Model
    {
        public string MOD_CODE { get; set; }
        public string MOD_MANUFACTURER { get; set; }
        public string MOD_NAME { get; set; }
        public int? MOD_SEATS { get; set; }
        public decimal? MOD_CHG_MILE { get; set; }
    }
}
