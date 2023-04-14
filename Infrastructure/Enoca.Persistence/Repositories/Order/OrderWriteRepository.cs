using Enoca.Application.Repositories.Order;
using Enoca.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<Enoca.Domain.Entities.Order, int>, IOrderWriteRepository
    {
        public OrderWriteRepository(EnocaDbContext context) : base(context)
        {
        }
    }
}
