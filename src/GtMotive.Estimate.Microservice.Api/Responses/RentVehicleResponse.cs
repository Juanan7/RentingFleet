using System;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public class RentVehicleResponse
    {
        public Guid VehicleId { get; init; }

        public string CustomerId { get; init; }
    }
}
