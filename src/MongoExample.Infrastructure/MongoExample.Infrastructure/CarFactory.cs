using MongoExample.Core.Boundaries;
using MongoExample.Core.Entities;
using MongoExample.Infrastructure.Entities;

namespace MongoExample.Infrastructure;

public class CarFactory : ICarFactory
{
    public Task<ICar> CreateCarAsync(int vin, string brand, string model, DateTime dateManufactured)
    {
        ICar car = new Car
        {
            Brand = brand,
            VIN = vin,
            Model = model,
            DateManufactured = dateManufactured
        };
        return Task.FromResult(car);
    }
}
