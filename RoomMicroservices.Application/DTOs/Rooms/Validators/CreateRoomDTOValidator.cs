using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.DTOs.Rooms.Validators
{
    public class CreateRoomDTOValidator : AbstractValidator<CreateRoomDTO>
    {
        public CreateRoomDTOValidator()
        {
            RuleFor(x => x.Floor).GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x=>x.BuildingId).GreaterThan(0);
            RuleFor(x=>x.Capacity).GreaterThan(0);
            RuleFor(x=>x.Number).NotNull().NotEmpty();
        }
    }
}
