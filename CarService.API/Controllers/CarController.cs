using CarService.App.Cars.Commands;
using CarService.App.Cars.Models;
using CarService.App.Cars.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers;

public class CarController : MediatorController
{
    /// <summary>
    /// Добавить автомобиль
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <response code="204"></response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Add([FromBody] CreateCarCommand request, CancellationToken token)
    {
        return Ok(await Mediator.Send(request, token));
    }

    
    /// <summary>
    /// Удалить автомобиль
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <response code="204"></response>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(string id, CancellationToken token)
    {
        await Mediator.Send(new DeleteCarCommand { Id = id }, token);
        return NoContent();
    }

    /// <summary>
    /// Обновить автомобиль
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <response code="204">Обновляет автомобиль</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Update(UpdateCarCommand request, CancellationToken token)
    {
        await Mediator.Send(request, token);
        return NoContent();
    }

    /// <summary>
    /// Получить список автомобилей
    /// </summary>
    /// <param name="grr"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <response code="200">Возвращает список клубов</response>
    [HttpPost]
    [Route("getRows")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CarDto>>> Get(GetCarsQuery query, CancellationToken token)
    {
        var res = await Mediator.Send(query, token);

        return Ok(res);
    }

    
}