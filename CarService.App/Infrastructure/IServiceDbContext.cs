using CarService.App.Cars.Models;
using CarService.App.Cars.Queries;
using CarService.Domain;

namespace CarService.App.Infrastructure;

public interface IServiceDbContext
{
    Task AddCar(Car car);

    Task<IEnumerable<Car>> GetCars(GetCarsQuery query);

    Task DeleteCar(string id);

    Task UpdateCar(Car car);

    Task<Car> GetById(string id);
}