using Business.Helper.ApiHelper;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public IWebHostEnvironment _hostingEnvironment;
        private readonly IApiHelper _api;

        public HomeController(IWebHostEnvironment hostingEnvironment,  IApiHelper api)
        {
            _hostingEnvironment = hostingEnvironment;
            _api = api;
        }
        public IActionResult HomePage()
        {
            var sender = GetCurrentUser();

            var message ="";
            var response = _api.GetObjectResponseFromApi<MessageDTO>(RestSharp.Method.POST, "Login/SignUp", message);

            return View();
        }
        public IActionResult Create(MessageDTO message)
        {
            if (ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender =  GetCurrentUser();
                message.ApplicationUserId = sender.Id;
                var response = _api.GetObjectResponseFromApi<MessageDTO>(RestSharp.Method.POST, "Home/AddMessage", message);
                return Ok();

            }
            return BadRequest();
        }
    }
}
