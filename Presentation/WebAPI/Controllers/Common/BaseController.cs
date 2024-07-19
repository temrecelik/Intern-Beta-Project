using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<
    TCreateRequest, TUpdateRequest, TDeleteRequest, TGetByIdRequest, TGetAllRequest, TDeleteResponse, TGetByIdResponse> : ControllerBase
    where TDeleteRequest : IRequest<TDeleteResponse>
    where TGetByIdRequest : IRequest<TGetByIdResponse>
{
    protected readonly IMediator Mediator;
    protected readonly ILogger<BaseController<TCreateRequest, TUpdateRequest, TDeleteRequest, TGetByIdRequest, TGetAllRequest, TDeleteResponse, TGetByIdResponse>> _logger;

    protected BaseController(ILogger<BaseController<TCreateRequest, TUpdateRequest, TDeleteRequest, TGetByIdRequest, TGetAllRequest, TDeleteResponse, TGetByIdResponse>> logger, IMediator mediator)
    {
        Mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TCreateRequest createCommand)
    {
        _logger.LogInformation("Add method called with request: {Request}", createCommand);
        var response = await Mediator.Send(createCommand!);
        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TUpdateRequest updateCommand)
    {
        _logger.LogInformation("Update method called with request: {Request}", updateCommand);
        var response = await Mediator.Send(updateCommand!);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        _logger.LogInformation("Delete method called with id: {Id}", id);
        var command = (TDeleteRequest)Activator.CreateInstance(typeof(TDeleteRequest), id)!;
        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        _logger.LogInformation("GetById method called with id: {Id}", id);
        var request = (TGetByIdRequest)Activator.CreateInstance(typeof(TGetByIdRequest), id)!;
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("GetAll method called");
        var query = (TGetAllRequest)Activator.CreateInstance(typeof(TGetAllRequest))!;
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}
