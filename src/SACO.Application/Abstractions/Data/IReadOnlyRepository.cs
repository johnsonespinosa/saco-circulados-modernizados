using Ardalis.Specification;
using SACO.SharedKernel;

namespace SACO.Application.Abstractions.Data;

public interface IReadOnlyRepository<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class, IAggregateRoot;