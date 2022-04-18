using Business.Abstract;
using Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        public LoginController(IApplicationUserService applicationUserService , ICountryService countryService,
            ICityService cityService)
        {
            _applicationUserService = applicationUserService;
            _countryService = countryService;
            _cityService = cityService;
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ApplicationUserDTO model)
        {
            var result = _applicationUserService.Update(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("SignUp")]
        public IActionResult SignUp([FromBody] ApplicationUserDTO model)
        {
            var result = _applicationUserService.SignUp(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid/{id=}")]
        public IActionResult GetById(int id)
        {
            var result = _applicationUserService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet("GetListCountryDTO/{id=}")]
        public ActionResult GetListCountryDTO()
        {
            var result = _countryService.GetList();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbycountry/{id=}")]                     
        public ActionResult GetAllByCountryId(int id)
        {
            var result = _cityService.GetAllByCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("EmailCodeSaved")]
        public IActionResult EmailCodeSaved([FromBody] EmailConfirmedDTO emailConfirmedDTO)
        {
            var result = _applicationUserService.EmailCodeSaved(emailConfirmedDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPost("EmailCodeControl")]
        public IActionResult EmailCodeControl([FromBody] EmailConfirmedDTO model)
        {
            var result = _applicationUserService.EmailCodeControl(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
