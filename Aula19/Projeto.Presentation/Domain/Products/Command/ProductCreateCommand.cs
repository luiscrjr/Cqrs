using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Domain.Products.Command
{
    public class ProductCreateCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        public decimal Price { get; set; }
    }
}
