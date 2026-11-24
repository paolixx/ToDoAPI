using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.RepositoryInterface;
using ToDo.Infrastructure.Persistence.Entities;

namespace ToDo.Infrastructure.Repository
{
    public class GenericRepository<TDomain, TEntity> :
        IGenericRepository<TDomain>
        where TDomain : class
        where TEntity : class
    {
        private readonly ToDoAppDbContext toDoAppDbContext;
        private readonly IMapper mapper;

        public GenericRepository(
            ToDoAppDbContext toDoAppDbContext,
            IMapper mapper)
        {
            this.toDoAppDbContext = toDoAppDbContext;
            this.mapper = mapper;
        }

        public async Task AddAsync(TDomain domain)
        {
            var entity = mapper.Map<TEntity>(domain);
            await toDoAppDbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> CommitAsync()
        {
            return await toDoAppDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            return await toDoAppDbContext.Set<TEntity>()
                .ProjectTo<TDomain>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TDomain?> GetByIdAsync(object id)
        {
            var entity = await toDoAppDbContext.Set<TEntity>().FindAsync(id);

            return entity == null ? null :
                mapper.Map<TDomain>(entity);
        }

        public async Task DetachAsync(object id)
        {
            var entity = await toDoAppDbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                toDoAppDbContext.Entry(entity).State = EntityState.Detached;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await toDoAppDbContext.Set<TEntity>().FindAsync(id);

            if (entity is not null) toDoAppDbContext.Set<TEntity>().Remove(entity);

            await Task.CompletedTask;
        }
    }
}
