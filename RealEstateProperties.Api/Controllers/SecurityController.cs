using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealEstateProperties.Core.DTOs;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public SecurityController(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        /// <summary>
        /// Método para obtener token JWT
        /// </summary>
        /// <param name="user"> Objeto User </param>
        /// <returns>Token generado</returns>
        [HttpPost]
        [Route("GetToken")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetToken(UserDto user)
        {
            var token = GenerateToken(user.User);

            return Ok(new
            {
                token = token
            });
        }



        #region GenerarToken
        private string GenerateToken(string user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim("User", user)
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Authentication:MinutesToken"]))
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

    }
}
