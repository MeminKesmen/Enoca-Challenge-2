using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Carrier.GetCarrier
{
    public class GetCarrierQueryRequest:IRequest<GetCarrierQueryResponse>
    {
        public int Id { get; set; }
    }
}
