using CarService.App.Infrastructure;
using MediatR;
using NodaTime;

namespace CarService.App.Cars.Commands;

public class UpdateCarCommand : IRequest
{
    public string Id { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!; 
    public string Color { get; set; } = null!;
    public LocalDate DateOfManufacture { get; set; } 
    public decimal Price { get; set; }
}

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
{
    private readonly IServiceDbContext _ctx;

    public UpdateCarCommandHandler(IServiceDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _ctx.GetById(request.Id);

        if (car == null)
        {
            throw new CustomException(ExceptionMessage.Car.NotFound());
        }
        
        await _ctx.UpdateCar(car);

        return Unit.Value;
    }
}