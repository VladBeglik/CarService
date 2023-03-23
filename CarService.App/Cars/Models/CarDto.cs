using NodaTime;

namespace CarService.App.Cars.Models;

public class CarDto 
{
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!; 
    public string Color { get; set; } = null!;
    public DateTime DateOfManufacture { get; set; } 
    public decimal Price { get; set; }
}