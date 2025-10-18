using Ardalis.Specification;
using SACO.SharedKernel;

namespace SACO.Application.Abstractions.Data;

public interface IGenericRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IAggregateRoot;