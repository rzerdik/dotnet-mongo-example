using System.ComponentModel.DataAnnotations;

namespace MongoExample.API.Dtos;

public class CarCreateDto
{
    [Required]
    public int VIN { get; set; }
    
    [Required]
    public string Brand { get; set; } = default!;
    
    [Required]
    public string Model { get; set; } = default!;
    
    public DateTime DateManufactured { get; set; } = DateTime.UtcNow;
}