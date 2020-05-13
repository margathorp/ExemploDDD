using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExemploDDD.Domain.Models;

namespace ExemploDDD.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity: EntityBase 
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);        
    }
}