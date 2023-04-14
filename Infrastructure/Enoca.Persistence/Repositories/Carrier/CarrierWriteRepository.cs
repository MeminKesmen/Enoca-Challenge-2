using Enoca.Application.Repositories.Carrier;
using Enoca.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories.Carrier
{
    public class CarrierWriteRepository : WriteRepository<Enoca.Domain.Entities.Carrier, int>, ICarrierWriteRepository
    {
        public CarrierWriteRepository(EnocaDbContext context) : base(context)
        {
        }
    }
}
