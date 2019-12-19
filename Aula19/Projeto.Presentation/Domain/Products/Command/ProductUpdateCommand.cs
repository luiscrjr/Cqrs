using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Domain.Products.Command
{
    public class ProductUpdateCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        public decimal Price { get; set; }
    }
}
