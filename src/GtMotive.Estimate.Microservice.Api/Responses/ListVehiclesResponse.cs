using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public class ListVehiclesResponse
    {
        public IEnumerable<VehicleResponse> Vehicles { get; init; }
    }
}
