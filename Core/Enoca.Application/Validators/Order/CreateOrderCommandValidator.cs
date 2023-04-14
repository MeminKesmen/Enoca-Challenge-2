using Enoca.Application.CQRS.Commands.Order.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Validators.Order
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.OrderDesi)
                .GreaterThan(0).WithMessage("Sipariş desi değeri 0 dan büyük olmalı!");
        }
    }
}
