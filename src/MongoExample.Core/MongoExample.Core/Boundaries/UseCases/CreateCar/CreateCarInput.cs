using MongoExample.Core.Exceptions;

namespace MongoExample.Core.Boundaries.UseCases.CreateCar;

public class CreateCarInput
{
    public CreateCarInput(int vin, string brand, string model, DateTime dateManufactured)
    {
        if (vin < 0)
            throw new InputParameterException($"{nameof(CreateCarInput)}-{nameof(vin)} - Vin cannot be {vin}");

        if (string.IsNullOrWhiteSpace(brand))
            throw new InputParameterException($"{nameof(CreateCarInput)}-{nameof(brand)}");

        if (string.IsNullOrWhiteSpace(model))
            throw new InputParameterException($"{nameof(CreateCarInput)}-{nameof(model)}");

        VIN = vin;
        Brand = brand;
        Model = model;
        DateManufactured = dateManufactured;
    }

    public int VIN { get; }

    public string Brand { get; }

    public string Model { get; }

    public DateTime DateManufactured { get; }
}
