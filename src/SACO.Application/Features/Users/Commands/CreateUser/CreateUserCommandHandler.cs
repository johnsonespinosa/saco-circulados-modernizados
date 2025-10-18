using SACO.Application.Abstractions.Auth;
using SACO.Application.Abstractions.Data;
using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.Specifications;
using SACO.Domain.Entities;
using SACO.Domain.Enums;
using SACO.Domain.Errors;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler(IGenericRepository<User> repository, IPasswordHasher passwordHasher) : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var spec = new UserByNameSpec(command.UserName);
        var exists = await repository.AnyAsync(spec, cancellationToken);

        if (exists)
            return Result.Failure<Guid>(error: UserErrors.UserNameNotUnique);
        
        var user = User.Create(
            command.UserName,
            passwordHasher.Hash(command.Password),
            rol: Enum.Parse<UserRol>(command.Rol));
        
        await repository.AddAsync(user, cancellationToken);

        return Result.Success(user.Id);
    }
}
