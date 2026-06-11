using System;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public class VehicleResponse
    {
        public Guid Id { get; init; }

        public string Brand { get; init; }

        public string Model { get; init; }

        public DateTime ManufactureDate { get; init; }

        public bool IsRented { get; init; }
    }
}
