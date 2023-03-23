using CarService.App.Infrastructure;
using MediatR;

namespace CarService.App.Cars.Commands;

public class DeleteCarCommand : IRequest
{
    public string Id { get; set; } = null!;
}

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly IServiceDbContext _ctx;

    public DeleteCarCommandHandler(IServiceDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        await _ctx.DeleteCar(request.Id);
        return Unit.Value;
    }
} 