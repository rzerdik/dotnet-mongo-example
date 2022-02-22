using MongoExample.Core.Entities;

namespace MongoExample.Core.Boundaries;

public interface ICarFactory
{
    Task<ICar> CreateCarAsync(int vin, string brand, string model, DateTime dateManufactured);
}
