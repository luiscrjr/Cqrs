using MongoDB.Driver;
using Projeto.Presentation.Domain.Products.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Cache
{
    public class ProductsCache
    {
        //atributo
        private readonly MongoDbContext context;

        //injeção de dependência
        public ProductsCache(MongoDbContext context)
        {
            this.context = context;
        }

        public void Create(ProductEntity product)
        {
            context.Products.InsertOne(product);
        }

        public void Update(ProductEntity product)
        {
            var filter = Builders<ProductEntity>.Filter.Where(p => p.Id.Equals(product.Id));
            context.Products.ReplaceOne(filter, product);
        }

        public void Delete(int id)
        {
            var filter = Builders<ProductEntity>.Filter.Where(p => p.Id.Equals(id));
            context.Products.DeleteOne(filter);
        }

        public List<ProductEntity> GetAll()
        {
            var filter = Builders<ProductEntity>.Filter.Where(p => true);
            return context.Products.Find(filter).ToList();
        }

        public ProductEntity GetById(int id)
        {
            var filter = Builders<ProductEntity>.Filter.Where(p => p.Id.Equals(id));
            return context.Products.Find(filter).FirstOrDefault();
        }
    }
}
