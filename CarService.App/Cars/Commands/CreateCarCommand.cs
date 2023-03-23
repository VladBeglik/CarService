using AutoMapper;
using CarService.App.Infrastructure;
using CarService.Domain;
using MediatR;
using NodaTime;

namespace CarService.App.Cars.Commands;

public class CreateCarCommand : IRequest 
{
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!; 
    public string Color { get; set; } = null!;
    public LocalDate DateOfManufacture { get; set; } 
    public decimal Price { get; set; }
}

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
{
    private readonly IServiceDbContext _ctx;
    private readonly IMapper _mapper;
    
    public CreateCarCommandHandler(IServiceDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<Car>(request);

        if (car == null)
        {
            throw new Exception();
        }

        await _ctx.AddCar(car);

        return Unit.Value;
    }
}