using FluentValidation;
using RealEstateProperties.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Infrastructure.Validators
{
    public class PropertyValidator : AbstractValidator<Property>
    {
        public PropertyValidator()
        {
            RuleFor(x => x.IdOwner)
                .NotNull()
                .WithMessage("El campo 'IdOwner' no pude ser nulo");
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("El campo 'Name' no puede ser nulo");
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("El campo 'Price' no puede ser nulo");
            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("El campo 'Address' no puede ser nulo");
        }
    }
}
