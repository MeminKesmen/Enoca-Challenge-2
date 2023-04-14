using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Repositories.Order
{
    public interface IOrderWriteRepository:IWriteRepository<Enoca.Domain.Entities.Order,int>
    {
    }
}
