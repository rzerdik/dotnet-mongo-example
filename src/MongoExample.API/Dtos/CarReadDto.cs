namespace MongoExample.API.Dtos;

public class CarReadDto
{
    public int VIN { get; set; }

    public string Brand { get; set; } = default!;

    public string Model { get; set; } = default!;

    public DateTime DateManufactured { get; set; }
}