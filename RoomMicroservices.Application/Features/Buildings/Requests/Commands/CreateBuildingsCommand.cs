using MediatR;
using RoomMicroservices.Application.DTOs.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Buildings.Requests.Commands
{
    public class CreateBuildingsCommand : IRequest<Unit>
    {
        public CreateBuildingDTO CreateBuildingDTO { get; set; }
    }
}
