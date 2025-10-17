using SACO.Domain.Entities;

namespace SACO.Application.Abstractions.Auth;

public interface ITokenProvider
{
    string Create(User user);
}