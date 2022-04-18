    using Business.Abstract;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IConfiguration _configuration;
        public TokenController(IApplicationUserService applicationUserService, IConfiguration configuration)
        {
            _applicationUserService = applicationUserService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public ResultDTO<ApplicationUserDTO> GetToken([FromBody] ApplicationUserDTO request)
        {
            ResultDTO<ApplicationUserDTO> response = new ResultDTO<ApplicationUserDTO>();

            response = _applicationUserService.SignIn(request.Email, request.Password);

            if (response != null)
            {


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Token:SigningKey"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, response.Data.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Data.Token = tokenHandler.WriteToken(token);
            }
            else
            {
                response.Success = false;
                response.Message = "LoginError";
            }

            return response;

        }
    }
}
