using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values =_discountService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            Discount discount = new Discount()
            {
                Title = createDiscountDto.Title,
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl,
                Status = createDiscountDto.Status,
            };

            _discountService.TAdd(discount);
            return Ok("İndirim eklendi.");

        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            Discount discount = new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Status = updateDiscountDto.Status,
            };
            _discountService.TUpdate(discount);
            return Ok("İndirim güncelle");


        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id) 
        { 
            var value=_discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim silindi");


        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value =_discountService.TGetById(id);
            return Ok(value);
        }
    }
}
