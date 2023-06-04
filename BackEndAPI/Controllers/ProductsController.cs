 using Application.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModels.Catalog.Products;
using ViewModels.Catalog.Products.ProductImages;
using ViewModels.Catalog.Productss;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IAdminProductService _adminProductService;
        public ProductsController(IPublicProductService publicProductService, IAdminProductService adminProductService)
        {
            _publicProductService = publicProductService;
            _adminProductService = adminProductService;
        }



        //http://localhost:port/product?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(languageId, request);
            return Ok(products);
        }
        //http://localhost:port/product/1
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _adminProductService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _adminProductService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _adminProductService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = product.Id, languageId = product.LanguageId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice( int productId, decimal newPrice)
        {
            var isScuccesful = await _adminProductService.UpdatePrice(productId, newPrice);
            if (isScuccesful)
                return Ok();
            return BadRequest();
        }
        //Image
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> Create( int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _adminProductService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();
            var image = await _adminProductService.GetImageById(imageId);
            return CreatedAtAction(nameof(GetById), new { id = image.Id }, image);
        }

        [HttpGet("{productId}/image/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _adminProductService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find image");
            return Ok(image);
        }


        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminProductService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();
          
            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _adminProductService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }


    }
}
