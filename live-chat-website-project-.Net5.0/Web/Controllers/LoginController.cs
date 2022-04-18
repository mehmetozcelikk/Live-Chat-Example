using Business.Helper.ApiHelper;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web.UserCookie;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        public IWebHostEnvironment _hostingEnvironment;
        private readonly IApiHelper _api;
        private readonly UserManager _userManager;

        public LoginController(IWebHostEnvironment hostingEnvironment,UserManager userManager, IApiHelper api )
        {
            _hostingEnvironment = hostingEnvironment;
            _api = api;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(ApplicationUserDTO applicationUserDTO)
        {

            var response = _api.GetObjectResponseFromApi<ApplicationUserDTO>(RestSharp.Method.POST, "Login/SignUp", applicationUserDTO);

            if (response.Success)
            {
                return Json(response);
            }
            else if (response.Success == false)
            {
                return Json(response);
            }
            return Json(response);


        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(ApplicationUserDTO model)
        {
            ResultDTO<ApplicationUserDTO> response = _userManager.SignIn(this.HttpContext, model);

            return Json(response);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetCountry()
        {
            var resultDtos = _api.GetObjectResponseFromApi<List<CountryDTO>>(RestSharp.Method.GET, "/Login/GetListCountryDTO/", null ).Data;
            return Json(resultDtos);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetCity(int id)
        {
            var resultDtos = _api.GetObjectResponseFromApi<List<CityDTO>>(RestSharp.Method.GET, "/Login/getallbycountry/" + id, null ).Data;
            return Json(resultDtos);
        }
    }
}
