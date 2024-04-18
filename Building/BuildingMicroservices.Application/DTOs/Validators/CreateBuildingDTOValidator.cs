using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.DTOs.Validators
{
    public class CreateBuildingDTOValidator : AbstractValidator<CreateBuildingDTO>
    {
        public CreateBuildingDTOValidator()
        {
            RuleFor(x=>x.Address).NotNull().NotEmpty();
            RuleFor(x => x.Floors).GreaterThan(0);
            RuleFor(x=>x.Name).NotNull().NotEmpty();
        }
    }
}
