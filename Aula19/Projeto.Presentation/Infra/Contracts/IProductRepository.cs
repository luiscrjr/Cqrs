using Projeto.Presentation.Domain.Products.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Infra.Contracts
{
    public interface IProductRepository
        : IBaseRepository<ProductEntity>
    {
    }
}
