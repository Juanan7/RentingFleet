using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class ListVehiclesController(
        IUseCase<ListVehiclesInput> listVehiclesUseCase,
        ListVehiclesPresenter presenter) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListVehicles()
        {
            await listVehiclesUseCase.Execute(new ListVehiclesInput());
            return presenter.ActionResult;
        }
    }
}
