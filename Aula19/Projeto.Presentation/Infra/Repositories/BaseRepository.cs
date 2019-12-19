using Microsoft.EntityFrameworkCore;
using Projeto.Presentation.Infra.Contexts;
using Projeto.Presentation.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        //atributo
        private readonly DataContext context;

        public BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task Create(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
