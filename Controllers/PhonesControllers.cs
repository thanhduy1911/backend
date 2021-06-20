using System.Threading.Tasks;
using backend.Constants;
using backend.Interfaces;
using backend.Models.Phone;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonesControllers : ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;
        public PhonesControllers(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PhoneDto>> GetPhones()
        {
            var phone = await _phoneRepository.GetPhones();
            return Ok(phone);
        }
        [HttpPost]
        public async Task<ActionResult<PhoneDto>> CreatePhone([FromBody] PhoneFormDto model)
        {
            var phone = await _phoneRepository.CreatePhone(model);
            return Created(Endpoint.Phone, phone);
        }
    }
}