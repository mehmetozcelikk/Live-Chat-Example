using Business.Abstract;
using Bussiness.Abstract;
using Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMessageService _messageService;
        public HomeController(IApplicationUserService applicationUserService, IMessageService messageService,
            ICityService cityService)
        {
            _applicationUserService = applicationUserService;
            _messageService = messageService;
        }
        [HttpPost("AddMessage")]
        public IActionResult AddMessage([FromBody] MessageDTO message)
        {
            var result = _messageService.AddMessage(message);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
