using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoExample.Core.Entities;

namespace MongoExample.Infrastructure.Entities;

public class Car : ICar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public int VIN { get; set; }
    public SPZ SPZ { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateTime DateManufactured { get; set; }
}
