using MongoExample.API.Models;

namespace MongoExample.API.Repositories;

public interface ICarRepository
{
    IQueryable<Car> GetAllCars();

    Task<Car> GetCarByVINAsync(int VIN);

    Task CreateCarAsync(Car car);

    Task DeleteCarAsync(Car car);
}