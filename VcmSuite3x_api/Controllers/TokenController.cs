using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using VcmSuite3x_api.Core.Models;
using VcmSuite3x_api.Core.Repository;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    public class TokenController : Controller
    {
        private readonly UnitOfWork unitOfw = new UnitOfWork();


        #region JWT Blog Informations (with .NET CORE)
        /*
         https://auth0.com/blog/securing-asp-dot-net-core-2-applications-with-jwts/
         https://tools.ietf.org/html/rfc7519#section-4
         */
        #endregion

        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            //_applicationRepository = application;
            _config = config;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginViewModel model)
        {
            Application application = Authenticate(model);

            if (application != null)
            {
                BaseViewModel<UserViewModel> baseObj = BuildToken(application);
                return Ok(baseObj);
            }

            return Unauthorized();
        }

        private Application Authenticate(LoginViewModel model)
        {


            Application application = unitOfw.ApplicationRepository.GetQuery(y => y.ApiKey == model.ApiKey && y.ApiSecretKey == model.ApiSecretKey);

            return application;
        }

        private BaseViewModel<UserViewModel> BuildToken(Application application)
        {
            DateTime issuedAt = DateTime.Now;
            DateTime expireOn = issuedAt.AddMinutes(30);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new[] { new Claim(JwtRegisteredClaimNames.Sid, application.Id.ToString()) };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"]
                                                , _config["Jwt:Issuer"]
                                                , claims
                                                , expires: DateTime.Now.AddMinutes(30)
                                                , signingCredentials: creds);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            application.ApiToken = tokenString;
            application.ApiTokenCreated = issuedAt;
            application.ApiTokenExpireOn = expireOn;
            unitOfw.ApplicationRepository.Update(application);

            UserViewModel model = new UserViewModel(tokenString, issuedAt, expireOn);
            return new BaseViewModel<UserViewModel>(model, "Token Generated Successfully!", application.ApiKey);

        }

    }
}
