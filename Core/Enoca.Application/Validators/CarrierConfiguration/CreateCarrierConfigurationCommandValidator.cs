using Enoca.Application.CQRS.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Validators.CarrierConfiguration
{
    public class CreateCarrierConfigurationCommandValidator : AbstractValidator<CreateCarrierConfigurationCommandRequest>
    {
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }
        public CreateCarrierConfigurationCommandValidator()
        {
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
