using Enoca.Application.CQRS.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Validators.CarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandValidator: AbstractValidator<UpdateCarrierConfigurationCommandRequest>
    {
        public UpdateCarrierConfigurationCommandValidator()
        {
            RuleFor(cc => cc.Id).GreaterThan(0).WithMessage("Kargo konfigurasyon id 0 dan büyük olmalı!");
            RuleFor(cc => cc.CarrierMaxDesi)
                .GreaterThan(0).WithMessage("Max Desi 0 dan büyük olmalı!");
            RuleFor(cc => cc.CarrierMinDesi)
                .GreaterThan(0).WithMessage("Min Desi 0 dan büyük olmalı!");
            RuleFor(cc => cc.CarrierCost)
                .GreaterThan(0).WithMessage("Kargo fiyatı 0 dan büyük olmalı!");
            RuleFor(cc => cc.CarrierId)
                .GreaterThan(0).WithMessage("Kargo id Desi 0 dan büyük olmalı!")
                .NotNull().WithMessage("Kargo id boş geçilemez!");
        }
    }
}
