using AutoMapper;
using BuildingMicroservices.Application.DTOs;
using BuildingMicroservices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Building, BuildingDTO>();
            CreateMap<CreateBuildingDTO, Building>();
        }
    }
}
