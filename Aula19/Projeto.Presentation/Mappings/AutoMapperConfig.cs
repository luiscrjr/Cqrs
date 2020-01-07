using AutoMapper;
using Projeto.Presentation.Domain.Products.Command;
using Projeto.Presentation.Domain.Products.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductCreateCommand, ProductEntity>();
            CreateMap<ProductUpdateCommand, ProductEntity>();
        }
    }
}
