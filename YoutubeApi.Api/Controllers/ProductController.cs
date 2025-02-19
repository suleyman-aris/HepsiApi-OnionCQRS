﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Products.Command.CreateProduct;
using YoutubeApi.Application.Features.Products.Command.DeleteProduct;
using YoutubeApi.Application.Features.Products.Command.UpdateProduct;
using YoutubeApi.Application.Features.Products.Queries.GetAllProduct;

namespace YoutubeApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProducts(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProducts(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}
