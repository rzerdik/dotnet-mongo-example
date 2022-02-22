namespace MongoExample.Core.Entities;

public interface ICar
{
    public int VIN { get; set; }

    public SPZ SPZ { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public DateTime DateManufactured { get; set; }
}
