using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using SakataBlog.Application.System.UserFolder;
using SakataBlog.ViewModel.System.UserFolder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginRequest request)
        {
            var token = await _userService.Authenticate(request);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            if (token.DataResult == null)
            {
                ModelState.AddModelError("", token.Message);
                return RedirectToAction("Index");
            }
            var userPrincipal = this.ValidateToken(token.DataResult);
            //test
            //var data = userPrincipal.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Role);
            //end test
            HttpContext.Session.SetString("Token", token.DataResult);

            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Append("_tokenLogin", token.DataResult, options);

            return RedirectToAction("Index", "Home");
        }

        //Ham dung de giai token
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}