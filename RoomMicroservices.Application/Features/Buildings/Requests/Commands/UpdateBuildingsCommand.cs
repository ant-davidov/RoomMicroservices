using MediatR;
using RoomMicroservices.Application.DTOs.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Buildings.Requests.Commands
{
    public class UpdateBuildingsCommand : IRequest<Unit>
    {
        public CreateBuildingDTO BuildingDTO { get; set; }
    }
}
