using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOF.Application.DOTs.Products;
using MOF.Application.Feature.Products.Commands;
using MOF.Application.Feature.Products.Requests;

namespace MOF.demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto productDto)
        {
            try
            {
                return Ok(await mediator.Send(new CreateProductCommand { ProductDto = productDto }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("productId")]
        public async Task<IActionResult> GetById(int productId)
        {
            return Ok(await mediator.Send(new GetProductByProductIdRequest(productId)));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await mediator.Send(new GetProductList()));
        }


        [HttpPut]
        public async Task<IActionResult> Put(ProductDto productDto, int productId)
        {
            try
            {
                return Ok(await mediator.Send(new UpdateProductCommand() { Product = productDto, ProductId = productId}));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteProductByIdCommand() { ProductId = productId }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
