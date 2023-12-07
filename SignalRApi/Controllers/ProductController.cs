using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
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
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductsStatus = y.ProductsStatus,
                CategoryName = y.Category.CategoryName
            });
           
            return Ok(values.ToList());


        }
		[HttpGet("ProductCount")]

		public IActionResult ProductCount()
		{
            return Ok(_productService.TProductCount());

		}


		[HttpGet("ProductCountByHamburger")]

		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());

		}

		[HttpGet("ProductCountByDrink")]

		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());

		}

		[HttpGet("ProductPriceAvg")]

		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());

		}

		[HttpGet("ProductNameByMaxPrice")]

		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice);

		}

		[HttpGet("ProductNameByMinPrice")]

		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice);

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
                CategoryID=createProductDto.CategoryID

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
                CategoryID = updateProductDto.CategoryID
            });

            return Ok("Ürün  Güncellendi");


        }
        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("indirim Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }

}
