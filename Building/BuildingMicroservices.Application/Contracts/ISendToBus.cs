using BuildingMicroservices.Application.DTOs;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.Contracts
{
    public interface ISendToBus
    {
        Task Send(CreateBuildingContract building);
    }
}
