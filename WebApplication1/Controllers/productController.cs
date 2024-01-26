using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DomainModels;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public productController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [Route("Product")]
        public async Task<IActionResult> getAllProductsAsync()
        {
            

            var products = await productRepository.GetProductsAsync();



            return Ok(mapper.Map<List<Product>>(products));
        }

        [Authorize]
        [HttpGet]
        [Route("Product/{productId:int}"), ActionName("getProductAsync")]
        public async Task<IActionResult> getProductAsync([FromRoute] int productId)
        {
            var product = await productRepository.GetProductByIdAsync(productId);

            if(product == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<Product>(product));
        }

        //[Authorize]
        [HttpPost]
        [Route("Product/Add")]
        public async Task<IActionResult> addProductAsync([FromBody] AddProductRequest request)
        {
            var session = HttpContext.Session.GetString("username");
            if (session == null)
            {
                return NotFound();
            }
            var product = await productRepository.AddProduct(mapper.Map<Models.Product>(request));

            return CreatedAtAction(nameof(getProductAsync),new { productId = product.productId},mapper.Map<Product>(product));


        }




        //[Authorize]
        [HttpPut]
        [Route("Product/{productId:int}")]
        public async Task<IActionResult> updateProductAsync([FromRoute] int productId, [FromBody] UpdateProductRequest request)
        {
            var session = HttpContext.Session.GetString("username");
            if (session == null)
            {
                return NotFound();
            }

            if (await productRepository.Exists(productId))
            {
                var updatedProduct = await productRepository.UpdateProduct(productId, mapper.Map<Models.Product>(request));
                if(updatedProduct != null)
                {
                    return Ok(mapper.Map<Product>(updatedProduct));
                }
            }
            return NotFound();
        }
        //[Authorize]
        [HttpDelete]
        [Route("Product/{productId:int}")]
        public async Task<IActionResult> deleteProductAsync([FromRoute] int productId)
        {
            var session = HttpContext.Session.GetString("username");
            if (session == null)
            {
                return NotFound();
            }
            if (await productRepository.Exists(productId))
            {
                var product = await productRepository.DeleteProductAsync(productId);
                if (product != null)
                {
                    return Ok(mapper.Map<Product>(product));
                }
            }
            return NotFound();
        }


    }
}
