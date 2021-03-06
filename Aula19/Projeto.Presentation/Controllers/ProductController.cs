﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Cache;
using Projeto.Presentation.Domain.Products.Command;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ProductsCache cache;

        //construtor para injeção de dependência
        public ProductController(IMediator mediator, ProductsCache cache)
        {
            this.mediator = mediator;
            this.cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductUpdateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new ProductDeleteCommand { Id = id };
            return Ok(await mediator.Send(command));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(cache.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = cache.GetById(id);

            if (item != null)
                return Ok(item);
            else
                return NoContent();
        }


    }
}