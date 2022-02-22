using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoExample.API.Models;

public class Car
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [Required]
    public int VIN { get; set; }

    [Required]
    public string Brand { get; set; } = default!;

    [Required]
    public string Model { get; set; } = default!;

    public DateTime DateManufactured { get; set; }
}
