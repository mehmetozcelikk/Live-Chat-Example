using Business.Helper.ApiHelper;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace Web.UserCookie
{
    public class UserManager
    {
        public static string userToken;
        private readonly IApiHelper _api;
        private readonly IHttpContextAccessor _accessor;
        public UserManager(IApiHelper api, IHttpContextAccessor accessor)
        {
            _api = api;
            _accessor = accessor;
        }
        public ResultDTO<ApplicationUserDTO> SignIn(HttpContext httpContext, ApplicationUserDTO login)
        {
            try
            {
                var token = _api.GetObjectResponseFromApi<ApplicationUserDTO>(RestSharp.Method.POST,
                    "Token/GetToken", login);
                userToken = token.Data.Token;
                if (token == null || string.IsNullOrEmpty(token.Data.Token))
                {
                    return new ResultDTO<ApplicationUserDTO> { Message = "Login is failed!", Success = false };
                }
                if (token.Success == false)
                {
                    return new ResultDTO<ApplicationUserDTO> { Message = token.Message, Success = false };
                }
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name,token.Data.Email)
                };
                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(token.Data),
                CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                var SigninTask = httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(7),
                });
                while (!SigninTask.IsCompleted)
                {
                    Thread.Sleep(100);
                }

                return token;
            }
            catch
            {
                return new ResultDTO<ApplicationUserDTO> { Message = "Login is failed!", Success = false };
            }
        }
        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims(ApplicationUserDTO response)
        {
            List<Claim> claim = new List<Claim>
            {
                new Claim("Secret", response.Token),
                new Claim("UserInfo", JsonConvert.SerializeObject(response)),
            };
            return claim;
        }
    }
    }
