using BuildingMicroservices.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Features.Buildings.Requests.Queries
{
    public class GetAllBuildingsRequest : IRequest<List<BuildingDTO>>
    {
        
    }
}
