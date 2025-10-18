using SACO.Application.Abstractions.Data;
using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.Specifications;
using SACO.Domain.Entities;
using SACO.Domain.Enums;
using SACO.Domain.Errors;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Commands.DisableUser;

public sealed class DisableUserCommandHandler(IGenericRepository<User> repository) : ICommandHandler<DisableUserCommand>
{
    public async Task<Result> Handle(DisableUserCommand command, CancellationToken cancellationToken)
    {
        var spec = new UserByIdSpec(command.Id);
        var user = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        if (user is null)
            return Result.Failure(UserErrors.NotFound(command.Id));

        user.Status = UserStatus.Inactivo;

        await repository.DeleteAsync(user, cancellationToken);
        return Result.Success();
    }
}
