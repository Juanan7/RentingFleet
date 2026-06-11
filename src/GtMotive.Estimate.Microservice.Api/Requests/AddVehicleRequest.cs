using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class AddVehicleRequest
    {
        [Required]
        public string Brand { get; init; }

        [Required]
        public string Model { get; init; }

        [JsonRequired]
        public DateTime ManufactureDate { get; init; }
    }
}
