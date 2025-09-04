using DddSample.Application.DTOs;
using DddSample.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DddSample.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductDto dto)
        {
            if (dto == null)
                return BadRequest("Product data is required");

            await _productService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
    }
}
