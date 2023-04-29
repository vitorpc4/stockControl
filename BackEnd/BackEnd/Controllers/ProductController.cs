using Application.Domain.Commands.ProductsCommands;
using Application.Domain.Queries.ProductsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            GetAllProducts getAll = new GetAllProducts();
            var result = await _mediator.Send(getAll);
            if (result.IsSuccess) return Ok(result.Value);
            return NotFound(result.Reasons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            GetProductById command = new GetProductById { Id = id };
            var result = await _mediator.Send(command);
            if (result.IsSuccess) return Ok(result.Value);
            return NotFound(result.Reasons);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess) return Ok(result.Value);
            return BadRequest(result.Reasons);  
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProdcut([FromBody] UpdateProductCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess) return Ok(result.Value);
            return BadRequest(result.Reasons);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            DeleteProductCommand command = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.Reasons);
        }
    }
}
