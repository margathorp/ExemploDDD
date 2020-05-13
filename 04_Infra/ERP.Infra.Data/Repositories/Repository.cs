using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Infra.Data.Context;
using ExemploDDD.Domain.Interfaces.Repositories;
using ExemploDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ClienteContext _context;

        public Repository(ClienteContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {          
            _context.Attach(entity);  
            _context.Update<TEntity>(entity);                      
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}