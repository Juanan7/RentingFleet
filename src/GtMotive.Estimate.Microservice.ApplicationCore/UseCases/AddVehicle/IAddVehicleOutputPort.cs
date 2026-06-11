namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle
{
    /// <summary>
    /// Output port for the <see cref="AddVehicleUseCase"/>.
    /// </summary>
    public interface IAddVehicleOutputPort :
        IOutputPortStandard<AddVehicleOutput>,
        IOutputPortNotFound
    {
    }
}
