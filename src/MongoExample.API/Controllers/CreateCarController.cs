using Microsoft.AspNetCore.Mvc;
using MongoExample.API.Dtos;
using MongoExample.API.Presenters;
using MongoExample.Core.Boundaries.UseCases.CreateCar;

namespace MongoExample.API.Controllers;

[Route("/api/cars")]
[ApiController]
public class CreateCarController : ControllerBase
{
    private readonly CreateCarPresenter _presenter;
    private readonly ICreateCarUseCase _useCase;

    public CreateCarController(ICreateCarUseCase useCase, ICreateCarOutputPort outputPort)
    {
        _useCase = useCase;
        _presenter = (CreateCarPresenter)outputPort;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CarReadDto>> CreateCarAsync(CarCreateDto car)
    {
        var input = new CreateCarInput(car.VIN, car.Brand, car.Model, car.DateManufactured);

        await _useCase.ExecuteAsync(input);

        return _presenter.Result;
    }
}
