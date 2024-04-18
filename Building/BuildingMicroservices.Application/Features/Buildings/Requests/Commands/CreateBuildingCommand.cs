using BuildingMicroservices.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Features.Buildings.Requests.Commands
{
    public class CreateBuildingCommand : IRequest<BuildingDTO>
    {
        public CreateBuildingDTO Building { get; set; }
    }
}
