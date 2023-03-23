using System.Drawing;
using NodaTime;

namespace CarService.Domain;

public class Car : BaseEntity
{
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!; 
    public string Color { get; set; } = null!;
    public LocalDate DateOfManufacture { get; set; } 
    public decimal Price { get; set; }
}
