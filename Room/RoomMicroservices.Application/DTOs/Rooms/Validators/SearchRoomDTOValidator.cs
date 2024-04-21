using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.DTOs.Rooms.Validators
{
    internal class SearchRoomDTOValidator : AbstractValidator<SearchRoomDTO>
    {
        public SearchRoomDTOValidator()
        {
            RuleFor(x => x.Floor).GreaterThan(0).When(x=>x.Floor != null);
            RuleFor(x=>x.BuildongId).GreaterThan(0).When(x=>x.BuildongId != null);
            RuleFor(x=>x.Skip).GreaterThan(-1);
            RuleFor(x=>x.Size).GreaterThan(0);
        }
    }
}
