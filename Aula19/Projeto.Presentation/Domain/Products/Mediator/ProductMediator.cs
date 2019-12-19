using AutoMapper;
using MediatR;
using Projeto.Presentation.Domain.Products.Command;
using Projeto.Presentation.Domain.Products.Entity;
using Projeto.Presentation.Infra.Contracts;
using Projeto.Presentation.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Presentation.Domain.Products.Mediator
{
    public class ProductMediator :
        IRequestHandler<ProductCreateCommand, string>,
        IRequestHandler<ProductUpdateCommand, string>,
        IRequestHandler<ProductDeleteCommand, string>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IProductRepository repository;

        //construtor para injeção de dependencia
        public ProductMediator(IMediator mediator, IMapper mapper, IProductRepository repository)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<string> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<ProductEntity>(request);
            await repository.Create(product);

            await mediator.Publish(new ProductActionNotification
            {
                Action = ActionNotification.Added,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });

            return await Task.FromResult("Produto cadastrado com sucesso.");
        }

        public async Task<string> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {

            var product = mapper.Map<ProductEntity>(request);
            await repository.Update(product);

            await mediator.Publish(new ProductActionNotification
            {
                Action = ActionNotification.Modified,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });

            return await Task.FromResult("Produto atualizado com sucesso.");
        }

        public async Task<string> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetById(request.Id);
            await repository.Delete(product);

            await mediator.Publish(new ProductActionNotification
            {
                Action = ActionNotification.Deleted,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });

            return await Task.FromResult("Produto excluído com sceusso.");
        }
    }
}
