using AutoMapper;
using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Application.DTOs;
using BuildingMicroservices.Application.Exceptions;
using BuildingMicroservices.Application.Features.Buildings.Requests.Commands;
using Common;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Features.Buildings.Handler.Commands
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, Unit>
    {
      
        private readonly IBuildingRepository _buildingRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public DeleteBuildingCommandHandler(IBuildingRepository buildingRepository, IPublishEndpoint publishEndpoint)
        {
            _buildingRepository = buildingRepository;
            _publishEndpoint = publishEndpoint;
         
        }
        public async Task<Unit> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"{request.Id}");
            await _buildingRepository.DeleteBuildingAsync(building);
            await _publishEndpoint.Publish(new DeleteBuildingContract { Id = request.Id });
            return Unit.Value;
        }
    }
}
