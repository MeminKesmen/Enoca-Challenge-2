using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Domain.Entities
{
    public class CarrierReport : BaseEntity<int>
    {
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; } = DateTime.Now;
        public DateTime OrderDate { get; set; }
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}
