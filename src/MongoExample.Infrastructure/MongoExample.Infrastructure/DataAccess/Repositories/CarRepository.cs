using MongoDB.Driver;
using MongoExample.API.Repositories;
using MongoExample.Core.Entities;
using MongoExample.Infrastructure.Entities;

namespace MongoExample.Infrastructure.DataAccess.Repositories;

public class CarRepository : ICarRepository
{
    private readonly MongoDbContext _context;

    public CarRepository(MongoDbContext context)
    {
        _context = context;
    }

    public Task CreateCarAsync(ICar car) => _context.Cars.InsertOneAsync((Car)car);

    public Task DeleteCarAsync(ICar car) => _context.Cars.DeleteOneAsync(c => c.VIN == car.VIN);

    public IQueryable<ICar> GetAllCars() => _context.Cars.AsQueryable();

    public async Task<ICar> GetCarByVINAsync(int VIN) => await _context.Cars.GetSingleAsync(car => car.VIN == VIN);
}
