using AutoMapper;
using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Application.DTOs;
using BuildingMicroservices.Application.Exceptions;
using BuildingMicroservices.Application.Features.Buildings.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Features.Buildings.Handler.Queries
{
    public class GetBuildingByIdRequestHandler : IRequestHandler<GetBuildingByIdRequest, BuildingDTO>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public GetBuildingByIdRequestHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<BuildingDTO> Handle(GetBuildingByIdRequest request, CancellationToken cancellationToken)
        {
           var building = await _buildingRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Not found with id {request.Id}");
            return _mapper.Map<BuildingDTO>(building);
        }
    }
}
