using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.CarrierConfiguration.GetCarrierConfiguration
{
    public class GetCarrierConfigurationQueryRequest:IRequest<GetCarrierConfigurationQueryResponse>
    {
        public int Id { get; set; }
    }
}
