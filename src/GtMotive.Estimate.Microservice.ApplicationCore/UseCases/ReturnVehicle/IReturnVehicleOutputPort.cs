namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output port for the <see cref="ReturnVehicleUseCase"/>.
    /// </summary>
    public interface IReturnVehicleOutputPort :
        IOutputPortStandard<ReturnVehicleOutput>,
        IOutputPortNotFound
    {
    }
}
