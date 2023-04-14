using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Order.GetOrder
{
    public class GetOrderQueryRequest:IRequest<GetOrderQueryResponse>
    {
        public int Id { get; set; }
    }
}
