using Enoca.Application.CQRS.Commands;
using Enoca.Application.Dto.Carrier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Carrier.GetCarrier
{
    public class GetCarrierQueryResponse:CommandBaseResponse
    {
        public GetCarrierDto Carrier{ get; set; }
    }
}
