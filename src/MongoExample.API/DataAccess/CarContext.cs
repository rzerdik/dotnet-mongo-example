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

        CarsContext.Indexes.CreateOne(
            new CreateIndexModel<Car>(Builders<Car>.IndexKeys.Ascending(c => c.VIN),
                new CreateIndexOptions {Unique = true}));
    }

    public IMongoCollection<Car> CarsContext => _db.GetCollection<Car>(CollectionName);
}