using Enoca.Application.CQRS.Commands;
using Enoca.Application.Dto.CarrierConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.CarrierConfiguration.GetAllCarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryResponse:CommandBaseResponse
    {
        public List<GetCarrierConfigurationDto> CarrierConfigurationList { get; set; }
        public int Count { get; set; }
    }
}
