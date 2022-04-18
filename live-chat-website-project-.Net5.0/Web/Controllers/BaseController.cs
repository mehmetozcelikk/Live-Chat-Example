using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;

namespace Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }
        public ApplicationUserDTO GetCurrentUser()
        {
            string userJson = HttpContext.User.Claims.Where(s => s.Type == "UserInfo").FirstOrDefault().Value;
            ApplicationUserDTO dto = JsonConvert.DeserializeObject<ApplicationUserDTO>(userJson);
            return dto;
        }
        public string GetToken()
        {
            string token = HttpContext.User.Claims.Where(s => s.Type == "Secret").FirstOrDefault().Value;
            return token;
        }
    }
}
