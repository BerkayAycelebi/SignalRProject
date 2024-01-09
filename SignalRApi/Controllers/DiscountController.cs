using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {

            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateDiscountDto createDiscountDto)
        {

            _discountService.TAdd(new Discount()
            {
                Title = createDiscountDto.Title,
                Description = createDiscountDto.Description,
                Amount = createDiscountDto.Amount,
                ImageUrl = createDiscountDto.ImageUrl,
                Status = createDiscountDto.Status
                
            });
            return Ok("İndirim eklendi.");



        }
        [HttpPut]

        public IActionResult UpdateContact(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                Description = updateDiscountDto.Description,
                Amount = updateDiscountDto.Amount,
                ImageUrl = updateDiscountDto.ImageUrl,
                Status = updateDiscountDto.Status
            });

            return Ok("İndirim  Güncellendi");


        }
		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Ürün İndirimi Aktif Hale Getirildi");
		}

		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Ürün İndirimi Pasif Hale Getirildi");
		}

		[HttpGet("GetListByStatusTrue")]
		public IActionResult GetListByStatusTrue()
		{
			return Ok(_discountService.TGetListByStatusTrue());
		}
	}
}
