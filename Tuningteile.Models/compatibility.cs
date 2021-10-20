using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile.Models
{
    public class compatibility
    {
        public int ModelID { get; set; }
        public int TuningPartId { get; set; }

        public Model Model { get; set; }
        public TuningPart TuningPart { get; set; }
    }
}
