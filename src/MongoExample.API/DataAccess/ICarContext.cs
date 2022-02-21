using MongoDB.Driver;
using MongoExample.API.Models;

namespace MongoExample.API.DataAccess;

public interface ICarContext
{
    IMongoCollection<Car> CarsContext { get; }
}