using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Domain.Entities
{
    public class Carrier:BaseEntity<int>
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost{ get; set; }

        public IEnumerable<CarrierConfiguration> CarrierConfigurations { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<CarrierReport> CarrierReports { get; set; }

    }
}
