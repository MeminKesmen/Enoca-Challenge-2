using Enoca.Application.Repositories.Order;
using Enoca.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Enoca.Domain.Entities.Order, int>, IOrderReadRepository
    {
        public OrderReadRepository(EnocaDbContext context) : base(context)
        {
        }
    }
}
