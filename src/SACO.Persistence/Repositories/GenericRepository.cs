using Ardalis.Specification.EntityFrameworkCore;
using SACO.Application.Abstractions.Data;
using SACO.SharedKernel;

namespace SACO.Persistence.Repositories;

internal sealed class GenericRepository<TEntity>(ApplicationDbContext dbContext)
    : RepositoryBase<TEntity>(dbContext), IGenericRepository<TEntity>
    where TEntity : class, IAggregateRoot;