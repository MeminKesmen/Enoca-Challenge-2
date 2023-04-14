using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Dto.CarrierReport
{
    public class CreateCarrierReportDto
    {
        public decimal CarrierCost { get; set; }
        public int CarrierId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
