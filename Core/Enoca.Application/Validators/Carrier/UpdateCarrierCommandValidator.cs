using Enoca.Application.CQRS.Commands.Carrier.UpdateCarrier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Validators.Carrier
{
    public class UpdateCarrierCommandValidator : AbstractValidator<UpdateCarrierCommandRequest>
    {
        public UpdateCarrierCommandValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Kargor id 0 dan büyük olmalı!");
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
