using Enoca.Application.CQRS.Commands.Carrier.CreateCarrier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Validators.Carrier
{
    public class CreateCarrierCommandValidator : AbstractValidator<CreateCarrierCommandRequest>
    {
        public CreateCarrierCommandValidator()
        {
            RuleFor(c => c.CarrierName)
                .NotNull().NotEmpty().WithMessage("Kargo adı boş geçilemez!");
            RuleFor(c => c.CarrierIsActive)
                .NotNull().WithMessage("Kargo durumu boş geçilemez!");
            RuleFor(c => c.CarrierPlusDesiCost)
                .NotNull().WithMessage("Kargo desi +1 ücreti boş geçilemez!")
                .GreaterThan(0).WithMessage("Kargo desi +1 ücreti 0 dan büyük olmalı!");
                
        }
    }
}
