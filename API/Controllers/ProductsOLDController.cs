using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[ApiController, Route("")]
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductsOLDController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductsOLDController(IProductRepo repo)
        {
            _repo = repo;            
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // var products = await _context.Products.ToListAsync();
            var products = await _repo.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) 
        {
            // var product = _context.Products.FirstOrDefault(x => x.Id == id);
            // var product = await _context.Products.FindAsync(id);//.Products.SingleOrDefault();
            var product = await _repo.GetByIdAsync(id);
            return Ok(product);
            // return await _context.Products.FindAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            // return await _repo.GetProductBrandsAsync();
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypess()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
        
    }
}