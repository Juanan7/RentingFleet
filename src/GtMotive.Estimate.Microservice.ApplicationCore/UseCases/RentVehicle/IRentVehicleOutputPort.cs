namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output port for the <see cref="RentVehicleUseCase"/>.
    /// </summary>
    public interface IRentVehicleOutputPort :
        IOutputPortStandard<RentVehicleOutput>,
        IOutputPortNotFound
    {
    }
}
