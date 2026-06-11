using System;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(RentVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new RentVehicleResponse
            {
                VehicleId = output.VehicleId,
                CustomerId = output.CustomerId.ToString(),
            };

            ActionResult = new OkObjectResult(response);
        }

        public void NotFoundHandle(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found",
                Detail = message,
            };

            ActionResult = new NotFoundObjectResult(problemDetails);
        }
    }
}
