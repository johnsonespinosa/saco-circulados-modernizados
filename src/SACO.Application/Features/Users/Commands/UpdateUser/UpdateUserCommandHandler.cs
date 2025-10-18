using SACO.Application.Abstractions.Data;
using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.Specifications;
using SACO.Domain.Entities;
using SACO.Domain.Enums;
using SACO.Domain.Errors;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler(IGenericRepository<User> repository) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var userByIdSpec = new UserByIdSpec(command.Id);
        var user = await repository.FirstOrDefaultAsync(userByIdSpec, cancellationToken);
        if (user is null)
            return Result.Failure(UserErrors.NotFound(command.Id));

        user.UserName = command.UserName;
        user.Rol = Enum.Parse<UserRol>(command.Rol);
        
        var userByNameSpec = new UserByNameSpec(command.UserName);
        var exists = await repository.AnyAsync(userByNameSpec, cancellationToken);

        if (exists)
            return Result.Failure<Guid>(error: UserErrors.UserNameNotUnique);

        await repository.UpdateAsync(user, cancellationToken);
        return Result.Success();
    }
}
