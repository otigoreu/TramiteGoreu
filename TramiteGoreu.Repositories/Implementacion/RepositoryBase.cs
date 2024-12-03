﻿using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<TEntity>> GetAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        public async Task<TEntity?> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAsync<Tkey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Tkey>> orderBy)
        {
            return await context.Set<TEntity>().Where(predicate).OrderBy(orderBy).AsNoTracking().ToListAsync();
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task UpdateAsync()
        {
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item is not null)
            {
                //item.Status = false;
                await UpdateAsync();
            }
        }


    }
}
