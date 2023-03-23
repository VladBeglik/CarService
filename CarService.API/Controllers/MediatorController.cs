using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers;

[Route("api/[controller]")]
public abstract class MediatorController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}

