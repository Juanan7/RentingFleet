using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class AddVehicleController(
        IUseCase<AddVehicleInput> addVehicleUseCase,
        AddVehiclePresenter presenter) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] AddVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new AddVehicleInput(request.Brand, request.Model, request.ManufactureDate);
            await addVehicleUseCase.Execute(input);
            return presenter.ActionResult;
        }
    }
}
