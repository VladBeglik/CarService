using AutoMapper;
using CarService.App.Cars.Models;
using CarService.App.Infrastructure;
using MediatR;

namespace CarService.App.Cars.Queries;

public class GetCarsQuery : IRequest<IEnumerable<CarDto>>
{
    public int Start { get; set; }
    public int End { get; set; }
}

public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IEnumerable<CarDto>>
{
    private readonly IServiceDbContext _ctx;
    private readonly IMapper _mapper;
    
    public GetCarsQueryHandler(IServiceDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        var data = await _ctx.GetCars(request);

        if (data == null)
        {
            throw new Exception();
        }

        var res = _mapper.Map<IEnumerable<CarDto>>(data);

        return res;
    }
}

