using MediatR;
using SACO.SharedKernel;

namespace SACO.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;