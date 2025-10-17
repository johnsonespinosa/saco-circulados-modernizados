using Ardalis.Specification.EntityFrameworkCore;
using SACO.Application.Abstractions.Data;
using SACO.SharedKernel;

namespace SACO.Persistence.Repositories;

internal sealed class ReadOnlyRepository<TEntity>(ApplicationDbContext dbContext)
    : RepositoryBase<TEntity>(dbContext), IReadOnlyRepository<TEntity>
    where TEntity : class, IAggregateRoot;