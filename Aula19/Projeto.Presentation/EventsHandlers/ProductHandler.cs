using MediatR;
using Projeto.Presentation.Cache;
using Projeto.Presentation.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Presentation.EventsHandlers
{
    public class ProductHandler : INotificationHandler<ProductActionNotification>
    {
        private readonly ProductsCache cache;

        public ProductHandler(ProductsCache cache)
        {
            this.cache = cache;
        }

        //construtor para injeção de dependência
        public Task Handle(ProductActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                switch (notification.Action)
                {
                    case ActionNotification.Added:
                        cache.Create(new Domain.Products.Entity.ProductEntity
                        {
                            Id = notification.Id,
                            Name = notification.Name,
                            Price = notification.Price
                        });
                        break;

                    case ActionNotification.Modified:
                        cache.Create(new Domain.Products.Entity.ProductEntity
                        {
                            Id = notification.Id,
                            Name = notification.Name,
                            Price = notification.Price
                        });
                        break;

                    case ActionNotification.Deleted:
                        cache.Delete(notification.Id);
                        break;
                }
            });
        }
    }
}
