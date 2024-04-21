using FluentValidation;
using RoomMicroservices.Application.DTOs.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.DTOs.Buildings.Validators
{
    public class BuildingDTOValidator : AbstractValidator<CreateBuildingDTO>
    {
        public BuildingDTOValidator()
        {
            RuleFor(x=>x.Address).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x=>x.Name).NotNull().NotEmpty();
            RuleFor(x=>x.Floors).GreaterThan(0);
        }
    }
}
