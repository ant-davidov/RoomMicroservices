using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Buildings.Requests.Commands
{
     public class DeleteBuildingsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
