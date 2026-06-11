using System;
using System.Linq;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class ListVehiclesPresenter : IWebApiPresenter, IListVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListVehiclesOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new ListVehiclesResponse
            {
                Vehicles = output.Vehicles.Select(v => new VehicleResponse
                {
                    Id = v.VehicleId,
                    Brand = v.Brand,
                    Model = v.Model,
                    ManufactureDate = v.ManufactureDate,
                    IsRented = false,
                }),
            };

            ActionResult = new OkObjectResult(response);
        }
    }
}
