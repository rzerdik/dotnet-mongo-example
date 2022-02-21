using System.Linq.Expressions;
using MongoDB.Driver;
using MongoExample.API.DataAccess;
using MongoExample.API.Models;

namespace MongoExample.API.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ICarContext _cars;

    public CarRepository(ICarContext cars)
    {
        _cars = cars;
    }

    public IQueryable<Car> GetAllCars() => _cars.CarsContext.AsQueryable();

    public async Task<Car> GetCarByVINAsync(int VIN) => await GetSingleAsync(car => car.VIN == VIN);

    public Task CreateCarAsync(Car car) => _cars.CarsContext.InsertOneAsync(car);

    public Task DeleteCarAsync(Car car) => _cars.CarsContext.DeleteOneAsync(c => c.VIN == car.VIN);

    private async Task<Car> GetSingleAsync(Expression<Func<Car, bool>> predicate)
    {
        var filter = Builders<Car>.Filter.Where(predicate);
        return (await _cars.CarsContext.FindAsync(filter)).FirstOrDefault();
    }
}