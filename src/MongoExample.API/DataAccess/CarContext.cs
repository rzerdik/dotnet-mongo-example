using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoExample.API.Models;

namespace MongoExample.API.DataAccess;

public class CarContext : ICarContext
{
    private const string CollectionName = "cars";
    private readonly IMongoDatabase _db;

    public CarContext(IOptions<DatabaseSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _db = client.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoCollection<Car> CarsContext => _db.GetCollection<Car>(CollectionName);
}