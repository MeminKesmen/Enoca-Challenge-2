using Enoca.Application.Repositories.CarrierReport;
using Enoca.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories.CarrierReport
{
    public class CarrierReportWriteRepository : WriteRepository<Enoca.Domain.Entities.CarrierReport, int>, ICarrierReportWriteRepository
    {
        public CarrierReportWriteRepository(EnocaDbContext context) : base(context)
        {
        }
    }
}
