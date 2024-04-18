using AutoMapper;
using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Application.DTOs;
using BuildingMicroservices.Application.Features.Buildings.Requests.Commands;
using BuildingMicroservices.Application.Features.Buildings.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Features.Buildings.Handler.Queries
{
    public class GetAllBuildingsRequestHandler : IRequestHandler<GetAllBuildingsRequest, List<BuildingDTO>>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public GetAllBuildingsRequestHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }
        public async Task<List<BuildingDTO>> Handle(GetAllBuildingsRequest request, CancellationToken cancellationToken)
        {
            var buildingList =  await _buildingRepository.GetAllBuildingsAsync();
            return _mapper.Map<List<BuildingDTO>>(buildingList);    
        }
    }
}
