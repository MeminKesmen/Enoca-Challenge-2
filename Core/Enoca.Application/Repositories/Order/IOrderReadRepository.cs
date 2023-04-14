using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Repositories.Order
{
    public interface IOrderReadRepository:IReadRepository<Enoca.Domain.Entities.Order,int>
    {
    }
}
