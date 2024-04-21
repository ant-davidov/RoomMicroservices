using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Buildings.Validators;
using RoomMicroservices.Application.Features.Buildings.Requests.Commands;
using RoomMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Buildings.Handlers.Commands
{
    public class UpdateBuildingsCommandHandler : IRequestHandler<UpdateBuildingsCommand, Unit>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public UpdateBuildingsCommandHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateBuildingsCommand request, CancellationToken cancellationToken)
        {
            var validator = new BuildingDTOValidator();
            var validationResult = validator.Validate(request.BuildingDTO);
            if (!validationResult.IsValid)
                Debug.WriteLine("UpdateBuildingDTO is not valid");

            var building = await _buildingRepository.GetByIdAsync(request.BuildingDTO.Id);
            
            _mapper.Map(request.BuildingDTO, building);
            await _buildingRepository.UpdateBuildingAsync(building);
            return Unit.Value;
        }
    }
}
