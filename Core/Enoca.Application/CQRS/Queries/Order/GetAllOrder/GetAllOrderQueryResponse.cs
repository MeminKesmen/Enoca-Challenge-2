using Enoca.Application.CQRS.Commands;
using Enoca.Application.Dto.Order;
using Enoca.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryResponse:CommandBaseResponse
    {
        public IDataResult<List<GetOrderDto>> OrderList { get; set; }
        public int Count { get; set; }
    }
}
