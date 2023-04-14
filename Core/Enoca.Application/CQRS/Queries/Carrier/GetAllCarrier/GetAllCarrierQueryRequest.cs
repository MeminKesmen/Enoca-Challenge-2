﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.CQRS.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryRequest:IRequest<GetAllCarrierQueryResponse>
    {
    }
}
