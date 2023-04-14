using Enoca.Application.CQRS.Commands;
using Enoca.Application.Dto.Carrier;
using Enoca.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryResponse:CommandBaseResponse
    {
        public IDataResult<List<GetCarrierDto>>? CarrierList{ get; set; }
        public int Count { get; set; }
    }
}
