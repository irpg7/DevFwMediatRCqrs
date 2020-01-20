using Business.Mediatr.Products.Commands.CreateProduct;
using Business.Mediatr.Products.Queries.GetProducts;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRestApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateProductCommand createProduct)
        {
           await _mediator.Send(createProduct);
            return StatusCode(201);
        }
    }
}
