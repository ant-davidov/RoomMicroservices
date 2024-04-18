using Common;
using MassTransit;
using MediatR;
using RoomMicroservices.Application.DTOs.Buildings;
using RoomMicroservices.Application.Features.Buildings.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Infrastructure
{
    public class BuildingConsumer : IConsumer<CreateBuildingContract>, IConsumer<DeleteBuildingContract>, IConsumer<UpdateBuildingContract>
    {
        private readonly IMediator _mediator;
        public BuildingConsumer(IMediator mediator)
        {
           _mediator = mediator;    
        }
        public async Task Consume(ConsumeContext<CreateBuildingContract> context)
        {
            var buildingDTO = new CreateBuildingDTO {  Address = context.Message.Address, Id = context.Message.Id, Name = context.Message.Name, Floors = context.Message.Floors };
            await _mediator.Send(new CreateBuildingsCommand {  CreateBuildingDTO = buildingDTO });
        }

        public async Task Consume(ConsumeContext<DeleteBuildingContract> context)
        {
            await _mediator.Send(new DeleteBuildingsCommand { Id = context.Message.Id });
        }

        public async Task Consume(ConsumeContext<UpdateBuildingContract> context)
        {
            var buildingDTO = new CreateBuildingDTO { Address = context.Message.Address, Id = context.Message.Id, Name = context.Message.Name, Floors = context.Message.Floors };
            await _mediator.Send(new UpdateBuildingsCommand { BuildingDTO = buildingDTO });
        }
    }
}
