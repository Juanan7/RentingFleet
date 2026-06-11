using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListVehicles
{
    /// <summary>
    /// Use case that returns all vehicles currently available for renting.
    /// </summary>
    public class ListVehiclesUseCase(IVehicleRepository vehicleRepository, IListVehiclesOutputPort outputPort) : IUseCase<ListVehiclesInput>
    {
        /// <inheritdoc/>
        public async Task Execute(ListVehiclesInput input)
        {
            var vehicles = await vehicleRepository.GetAvailableAsync();

            var dtos = vehicles
                .Select(v => new VehicleDto(v.Id.ToGuid(), v.Brand, v.Model, v.ManufactureDate.Value))
                .ToList();

            outputPort.StandardHandle(new ListVehiclesOutput(dtos));
        }
    }
}
