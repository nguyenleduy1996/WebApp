 using Application.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModels.Catalog.Products;
using ViewModels.Catalog.Productss;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IAdminProductService _adminProductService;
        public ProductController(IPublicProductService publicProductService, IAdminProductService adminProductService)
        {
            _publicProductService = publicProductService;
            _adminProductService = adminProductService;
        }
        //http://localhost:port/product

        [HttpGet]
        public async Task<IActionResult> Get(string languageId, string test)
        {
            var products = await _publicProductService.GetAll(languageId);
            return Ok(products);
        }
        //http://localhost:port/product/public-paging
        [HttpGet("public-paing/{languageId}")]
        public async Task<IActionResult> Get([FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(request);
            return Ok(products);
        }
        //http://localhost:port/product/1
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var product = await _adminProductService.GetById(id, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            var productId = await _adminProductService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _adminProductService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = product.Id, languageId = product.LanguageId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest request)
        {
            var affectedResult = await _adminProductService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


        [HttpDelete("{productId}")]
        public async Task<IActionResult> Update(int productId)
        {
            var affectedResult = await _adminProductService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice( int id, decimal newPrice)
        {
            var isScuccesful = await _adminProductService.UpdatePrice(id, newPrice);
            if (isScuccesful)
                return Ok();
            return BadRequest();
        }
    }
}
