using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application.DTOs
{
    public class CreateBuildingDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Floors { get; set; }
        public string Other { get; set; }
    }
}
