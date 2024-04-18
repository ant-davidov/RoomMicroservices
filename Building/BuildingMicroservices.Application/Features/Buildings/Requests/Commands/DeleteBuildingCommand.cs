using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Features.Buildings.Requests.Commands
{
    public class DeleteBuildingCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
