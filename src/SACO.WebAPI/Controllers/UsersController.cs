using MediatR;
using Microsoft.AspNetCore.Mvc;
using SACO.Application.Features.Users.Commands.CreateUser;
using SACO.Application.Features.Users.Commands.DisableUser;
using SACO.Application.Features.Users.Commands.UpdateUser;
using SACO.Application.Features.Users.DTOs;
using SACO.Application.Features.Users.Queries.GetAllUsers;
using SACO.Application.Features.Users.Queries.GetUserById;
using SACO.SharedKernel;

namespace SACO.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<UserDto>>> GetAll([FromQuery] UserFilterDto filter)
    {
        var result = await mediator.Send(new GetAllUsersQuery(filter));
        return result.IsSuccess ? Ok(result.Value) : Problem(result.Error.Message);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        var result = await mediator.Send(new GetUserByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error.Message);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value }, null) : Problem(result.Error.Message);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserDto dto)
    {
        var command = new UpdateUserCommand(id, dto.UserName, dto.Rol);
        var result = await mediator.Send(command);
        return result.IsSuccess ? NoContent() : Problem(result.Error.Message);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Disable(Guid id)
    {
        var result = await mediator.Send(new DisableUserCommand(id));
        return result.IsSuccess ? NoContent() : Problem(result.Error.Message);
    }
}