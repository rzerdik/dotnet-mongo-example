using MongoExample.Core.Entities;

namespace MongoExample.API.Repositories;

public interface ICarRepository
{
    IQueryable<ICar> GetAllCars();

    Task<ICar> GetCarByVINAsync(int VIN);

    Task CreateCarAsync(ICar car);

    Task DeleteCarAsync(ICar car);
}
