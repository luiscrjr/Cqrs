using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Domain.Products.Command
{
    public class ProductDeleteCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public int Id { get; set; }
    }
}
