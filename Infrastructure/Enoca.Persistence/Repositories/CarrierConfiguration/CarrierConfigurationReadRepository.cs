using Enoca.Application.Repositories.CarrierConfiguration;
using Enoca.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories.CarrierConfiguration
{
    public class CarrierConfigurationReadRepository : ReadRepository<Enoca.Domain.Entities.CarrierConfiguration, int>, ICarrierConfigurationReadRepository
    {
        public CarrierConfigurationReadRepository(EnocaDbContext context) : base(context)
        {
        }
    }
}
