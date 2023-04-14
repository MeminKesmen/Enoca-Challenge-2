using Enoca.Application.Repositories.CarrierReport;
using Enoca.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories.CarrierReport
{
    public class CarrierReportReadRepository : ReadRepository<Enoca.Domain.Entities.CarrierReport, int>, ICarrierReportReadRepository
    {
        public CarrierReportReadRepository(EnocaDbContext context) : base(context)
        {
        }
    }
}
