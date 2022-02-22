using MongoDB.Driver;
using MongoExample.Infrastructure.Entities;

namespace MongoExample.Infrastructure.DataAccess;

public class MongoDbContext
{
    private readonly IMongoDatabase _db;

    public MongoDbContext(DatabaseSettings options)
    {
        var client = new MongoClient(options.ConnectionString);
        _db = client.GetDatabase(options.DatabaseName);
    }

    public IMongoCollection<Car> Cars => _db.GetCollection<Car>("cars");
    public IMongoCollection<Brand> Brands => _db.GetCollection<Brand>("brands");
}
