using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]

        public IActionResult ContactList() 
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        
        
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                Location = createContactDto.Location,
                Phone = createContactDto.Phone,
                Mail = createContactDto.Mail,
                FooterDescription = createContactDto.FooterDescription,
                FooterTitle = createContactDto.FooterTitle,
                OpenDays = createContactDto.OpenDays,
                OpenDaysDescription = createContactDto.OpenDaysDescription,
                OpenHours = createContactDto.OpenHours,
            };
            _contactService.TAdd(contact);
            return Ok("İletişim bilgisi eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteContact(int id) 
        {
            var value=_contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact()
            {
                ContactID = updateContactDto.ContactID,
                Location = updateContactDto.Location,
                Phone = updateContactDto.Phone,
                Mail = updateContactDto.Mail,
                FooterDescription = updateContactDto.FooterDescription,
                FooterTitle = updateContactDto.FooterTitle,
                OpenDays = updateContactDto.OpenDays,
                OpenDaysDescription = updateContactDto.OpenDaysDescription,
                OpenHours = updateContactDto.OpenHours,
            };
            _contactService.TUpdate(contact);
            return Ok("İletişim güncellendi");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
}
