using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class RentVehicleController(
        IUseCase<RentVehicleInput> rentVehicleUseCase,
        RentVehiclePresenter presenter) : ControllerBase
    {
        [HttpPost("{id}/rent")]
        public async Task<IActionResult> RentVehicle(Guid id, [FromBody] RentVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new RentVehicleInput(id, new CustomerId(request.CustomerId));
            await rentVehicleUseCase.Execute(input);
            return presenter.ActionResult;
        }
    }
}
