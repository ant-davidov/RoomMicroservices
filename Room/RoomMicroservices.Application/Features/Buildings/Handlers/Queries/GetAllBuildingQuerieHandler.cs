using AutoMapper;
using MediatR;
using RoomMicroservices.Application.Contracts;
using RoomMicroservices.Application.DTOs.Buildings;
using RoomMicroservices.Application.Features.Buildings.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMicroservices.Application.Features.Buildings.Handlers.Queries
{
    public class GetAllBuildingQuerieHandler : IRequestHandler<GetAllBuildingQuerie, List<BuildingDTO>>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public GetAllBuildingQuerieHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }
        public async Task<List<BuildingDTO>> Handle(GetAllBuildingQuerie request, CancellationToken cancellationToken)
        {
           var list =  await _buildingRepository.GetAllBuildingsAsyn();
            return _mapper.Map<List<BuildingDTO>>(list);
        }
    }
}
