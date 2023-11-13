using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {

            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {

            _productService.TAdd(new Product()
            {
               ProductName = createProductDto.ProductName,
               Description = createProductDto.Description,
               Price = createProductDto.Price,
               ImageUrl = createProductDto.ImageUrl,
               ProductsStatus = createProductDto.ProductsStatus,

            });
            return Ok("Ürün eklendi.");



        }
        [HttpPut]

        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                ImageUrl = updateProductDto.ImageUrl,
                ProductsStatus = updateProductDto.ProductsStatus,
            });

            return Ok("Ürün  Güncellendi");


        }
        [HttpDelete]

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("indirim Silindi");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetFeature(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
    
}
