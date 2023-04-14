using Enoca.Application.Repositories.CarrierConfiguration;
using Enoca.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories.CarrierConfiguration
{
    public class CarrierConfigurationWriteRepository : WriteRepository<Enoca.Domain.Entities.CarrierConfiguration, int>, ICarrierConfigurationWriteRepository
    {
        public CarrierConfigurationWriteRepository(EnocaDbContext context) : base(context)
        {
        }
    }
}
