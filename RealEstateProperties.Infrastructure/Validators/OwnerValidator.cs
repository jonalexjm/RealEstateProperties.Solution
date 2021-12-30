using FluentValidation;
using RealEstateProperties.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Infrastructure.Validators
{
    public  class OwnerValidator : AbstractValidator<Owner>
    {
        public OwnerValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()                
                .WithMessage("El campo 'Name' no pude ser nulo");
            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("El campo 'Address' no puede ser nulo");

        }
    }
}
