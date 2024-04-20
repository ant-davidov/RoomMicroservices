using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingMicroservices.Application
{
    internal class RabbitMqOptions
    {
        public string Hostname { get; set; } = null!;
        public string VirtualHost { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
