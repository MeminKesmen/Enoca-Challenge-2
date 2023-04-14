﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.API.Controllers
{
    
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
