using Projeto.Presentation.Domain.Products.Entity;
using Projeto.Presentation.Infra.Contexts;
using Projeto.Presentation.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Infra.Repositories
{
    public class ProductRepository 
        : BaseRepository<ProductEntity>, IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
