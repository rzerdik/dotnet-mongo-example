using Microsoft.AspNetCore.Mvc;
using MongoExample.API.Dtos;
using MongoExample.Core.Boundaries.UseCases.CreateCar;

namespace MongoExample.API.Presenters;

public class CreateCarPresenter : ICreateCarOutputPort
{
    public ActionResult Result { get; private set; } = new EmptyResult();

    public void BrandModelMismatch() => Result = new BadRequestObjectResult("The brand or model is not valid.");

    public void BrandNotFound() => Result = new NotFoundObjectResult("Brand not found.");

    public void Created(int vin, string brand, string model, DateTime dateManufactured)
    {
        var car = new CarReadDto
        {
            Brand = brand,
            Model = model,
            DateManufactured = dateManufactured,
            VIN = vin
        };

        Result = new JsonResult(car);
    }

    public void DateManufacturedIsInFuture() => Result = new BadRequestObjectResult("The manufactured date cannot be in the future.");
}
