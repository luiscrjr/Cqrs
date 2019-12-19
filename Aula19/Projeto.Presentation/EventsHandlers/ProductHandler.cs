using MediatR;
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
        public Task Handle(ProductActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var result = $"Produto: {notification.Id}, Nome: {notification.Name}, Preço: {notification.Price} - "
                            + $"{notification.Action.ToString()} em {DateTime.Now}";

                Debug.WriteLine($"");
            });
        }
    }
}
