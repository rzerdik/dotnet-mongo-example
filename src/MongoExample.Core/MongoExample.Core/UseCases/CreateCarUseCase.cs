using MongoExample.API.Repositories;
using MongoExample.Core.Boundaries;
using MongoExample.Core.Boundaries.DataAccess;
using MongoExample.Core.Boundaries.UseCases.CreateCar;

namespace MongoExample.Core.UseCases;

public class CreateCarUseCase : ICreateCarUseCase
{
    private readonly IBrandService _brandService;
    private readonly ICarFactory _carFactory;
    private readonly ICarRepository _carRepository;
    private readonly IDateTime _dateTime;
    private readonly ICreateCarOutputPort _outputPort;

    public CreateCarUseCase(ICreateCarOutputPort outputPort, IBrandService brandService, IDateTime dateTime, ICarFactory carFactory, ICarRepository carRepository)
    {
        _outputPort = outputPort;
        _brandService = brandService;
        _dateTime = dateTime;
        _carFactory = carFactory;
        _carRepository = carRepository;
    }

    public async Task ExecuteAsync(CreateCarInput input)
    {
        if (await _brandService.BrandExistsAsync(input.Brand) == false)
        {
            _outputPort.BrandNotFound();
            return;
        }

        if (await _brandService.ModelExistsForBrandAsync(input.Brand, input.Model) == false)
        {
            _outputPort.BrandModelMismatch();
            return;
        }

        if (input.DateManufactured > _dateTime.Now)
        {
            _outputPort.DateManufacturedIsInFuture();
            return;
        }

        var car = await _carFactory.CreateCarAsync(input.VIN, input.Brand, input.Model, input.DateManufactured);
        await _carRepository.CreateCarAsync(car);
        _outputPort.Created(car.VIN, car.Brand, car.Model, car.DateManufactured);
    }
}
