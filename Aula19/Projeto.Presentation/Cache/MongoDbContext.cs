using MongoDB.Driver;
using Projeto.Presentation.Configurations;
using Projeto.Presentation.Domain.Products.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Cache
{
    public class MongoDbContext
    {
        public readonly MongoDbSettings settings;
        public readonly IMongoDatabase database;

        public MongoDbContext(MongoDbSettings settings)
        {
            this.settings = settings;

            var clientSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.Host));

            if (settings.IsSSL)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            var mongoClient = new MongoClient(clientSettings);
            database = mongoClient.GetDatabase(settings.Database);
        }

        //NOSQL -> tabelas = collections
        public IMongoCollection<ProductEntity> Products
        {
            get { return database.GetCollection<ProductEntity>("Products"); }
        }
    }
}
