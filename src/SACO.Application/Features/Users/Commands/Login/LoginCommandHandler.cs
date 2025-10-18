using SACO.Application.Abstractions.Auth;
using SACO.Application.Abstractions.Data;
using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;
using SACO.Application.Features.Users.Specifications;
using SACO.Domain.Entities;
using SACO.Domain.Errors;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Commands.Login;

internal sealed class LoginCommandHandler(IReadOnlyRepository<User> repository, IPasswordHasher passwordHasher) : ICommandHandler<LoginCommand, UserDto>
{
    public async Task<Result<UserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var spec = new UserByCredentialsSpec(request.UserName);
        var user = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        if (user is null || !passwordHasher.Verify(request.Password, user.PasswordHash))
            return Result.Failure<UserDto>(error: UserErrors.Unauthorized());

        return Result.Success(new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Rol = user.Rol.ToString(),
            Status = user.Status.ToString()
        });
    }
}