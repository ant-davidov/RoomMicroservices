using AutoMapper;
using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Application.DTOs;
using BuildingMicroservices.Application.DTOs.Validators;
using BuildingMicroservices.Application.Exceptions;
using BuildingMicroservices.Application.Features.Buildings.Requests.Commands;
using BuildingMicroservices.Domain;
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
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, BuildingDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public CreateBuildingCommandHandler(IMapper mapper, IBuildingRepository buildingRepository, IPublishEndpoint publishEndpoint)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<BuildingDTO> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBuildingDTOValidator();
            var validationResult = validator.Validate(request.Building);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);
            var building = _mapper.Map<Building>(request.Building);
            await _buildingRepository.AddBuildingAsync(building);
            var dto = _mapper.Map<BuildingDTO>(building);
            await _publishEndpoint.Publish<CreateBuildingContract>(new CreateBuildingContract { Address= dto.Address, Id = dto.Id, Name = dto.Name, Floors = dto.Floors});
            return dto;
        }
    }
}
