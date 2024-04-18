using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.Features.Buildings.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Buildings.Handlers.Commands
{
    public class DeleteBuildingsCommandHandler : IRequestHandler<DeleteBuildingsCommand, Unit>
    {
        private readonly IBuildingRepository _buildingRepository;
        public DeleteBuildingsCommandHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;    
        }
        public async Task<Unit> Handle(DeleteBuildingsCommand request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetByIdAsync(request.Id);
            await _buildingRepository.DeleteBuildingAsync(building);
            return Unit.Value;
        }
    }
}
