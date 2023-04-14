using Enoca.Application.CQRS.Commands;
using Enoca.Application.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Order.GetOrder
{
    public class GetOrderQueryResponse:CommandBaseResponse
    {
        public GetOrderDto Order { get; set; }
    }
}
