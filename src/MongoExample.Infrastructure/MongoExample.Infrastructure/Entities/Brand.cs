using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoExample.Core.Entities;

namespace MongoExample.Infrastructure.Entities;

public class Brand : IBrand
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public IEnumerable<string> AvailableModels { get; set; }
}
