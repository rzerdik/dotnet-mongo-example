namespace MongoExample.Core.Boundaries.UseCases.CreateCar;

public interface ICreateCarUseCase
{
    Task ExecuteAsync(CreateCarInput input);
}
