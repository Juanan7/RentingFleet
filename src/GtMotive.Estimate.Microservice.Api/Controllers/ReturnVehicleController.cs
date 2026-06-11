using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class ReturnVehicleController(
        IUseCase<ReturnVehicleInput> returnVehicleUseCase,
        ReturnVehiclePresenter presenter) : ControllerBase
    {
        [HttpPost("{id}/return")]
        public async Task<IActionResult> ReturnVehicle(Guid id)
        {
            var input = new ReturnVehicleInput(id);
            await returnVehicleUseCase.Execute(input);
            return presenter.ActionResult;
        }
    }
}
