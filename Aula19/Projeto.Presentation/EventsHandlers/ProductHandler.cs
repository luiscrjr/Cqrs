using MediatR;
using Newtonsoft.Json;
using Projeto.Presentation.Cache;
using Projeto.Presentation.Domain.Products.Entity;
using Projeto.Presentation.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            ProductEntity produto = new ProductEntity();

            return Task.Run(() =>
            {
                produto.Id = notification.Id;
                produto.Name = notification.Name;
                produto.Price = notification.Price;

                switch (notification.Action)
                {
                    case ActionNotification.Added:
                        cache.Create(produto);
                        break;

                    case ActionNotification.Modified:
                        cache.Create(produto);
                        break;

                    case ActionNotification.Deleted:
                        cache.Delete(produto.Id);
                        break;
                }

                sendMail(notification, produto);

                writeDebug(notification, produto);

            });
        }

        private void sendMail(ProductActionNotification notification, ProductEntity produto)
        {
            var mail = new MailMessage("securemailerserver@gmail.com", "luis.claudio.jr@hotmail.com");
            mail.Subject = $"Product {notification.Action.ToString().ToUpper()}";
            mail.Body = JsonConvert.SerializeObject(produto, Formatting.Indented);
            mail.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("securemailerserver@gmail.com", "secCustomnP@$$");
            smtp.Send(mail);
        }

        private void writeDebug(ProductActionNotification notification, ProductEntity produto)
        {
            Debug.WriteLine($"Product {produto.Id}, {produto.Name} " +
                    $" {notification.Action.ToString().ToUpper()}");
        }
    }
}
