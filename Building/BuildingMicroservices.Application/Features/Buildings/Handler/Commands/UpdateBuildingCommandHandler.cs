using AutoMapper;
using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Application.DTOs;
using BuildingMicroservices.Application.DTOs.Validators;
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
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand, BuildingDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public UpdateBuildingCommandHandler(IMapper mapper, IBuildingRepository buildingRepository, IPublishEndpoint publishEndpoint)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<BuildingDTO> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBuildingDTOValidator();
            var validationResult = validator.Validate(request.BuildingDTO);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);
            var building = await _buildingRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"{request.Id}");
            building = _mapper.Map(request.BuildingDTO, building);
            if (await _buildingRepository.NameAlreadyExistsAsync(building.Name, building.Id))
                throw new ValidationException($"name already exists {building.Name}");

            using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            cancellationToken = cancellationTokenSource.Token;
            using var transaction = _buildingRepository.CreateTransaction();
            try
            { 
                await _buildingRepository.UpdateBuildingAsync(building);
                await _publishEndpoint.Publish(new UpdateBuildingContract { Address = building.Address, Id = building.Id, Name = building.Name, Floors = building.Floors }, cancellationToken);
                transaction.Commit();
                return _mapper.Map<BuildingDTO>(building);
                
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                transaction.Rollback();
                throw new ConflictException($"tiomeout add rabbit {ex.Message}");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
          
        }
    }
}
