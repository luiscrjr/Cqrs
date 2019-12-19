using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Infra.Contracts
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<TEntity> GetById(int id);
    }
}
