using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.controllers
{
    //[ApiController, Route("")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsControllerOLD : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductsControllerOLD(IProductRepo repo)
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