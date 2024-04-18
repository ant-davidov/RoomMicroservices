using BuildingMicroservices.Application.Contracts;
using BuildingMicroservices.Application.DTOs;
using Common;
using MassTransit;

namespace BuildingMicroservices.Infrastructure
{
    public class SendToBus : ISendToBus
    {
        private readonly IBus _bus;
        public SendToBus(IBus bus)
        {
            _bus = bus;
        }
        public async Task Send(CreateBuildingContract building)
        {
            Uri uri = new Uri("rabbitmq://localhost/buildingConsumerQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(building);
            return;
        }
    }
}