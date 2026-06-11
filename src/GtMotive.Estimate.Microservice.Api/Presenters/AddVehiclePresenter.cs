using System;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class AddVehiclePresenter : IWebApiPresenter, IAddVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(AddVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new VehicleResponse
            {
                Id = output.VehicleId,
                Brand = output.Brand,
                Model = output.Model,
                ManufactureDate = output.ManufactureDate,
                IsRented = false,
            };

            ActionResult = new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        public void NotFoundHandle(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = message,
            };

            ActionResult = new BadRequestObjectResult(problemDetails);
        }
    }
}
