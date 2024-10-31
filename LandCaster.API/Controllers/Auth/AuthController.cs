using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LandCaster.API.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IManageLogic _manageLogic;

        public AuthController(UserManager<User> userManager, IConfiguration configuration, IManageLogic manageLogic)
        {
            _userManager = userManager;
            _configuration = configuration;
            _manageLogic = manageLogic;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(Credentials credentials)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user is null)
            {
                return Unauthorized(new AuthenticationResponse
                {
                    User = null,
                    Token = null,
                    Message= "Ususario no encontrado"
                });
            }
            var checkPassword = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!checkPassword)
            {
                return Unauthorized(new AuthenticationResponse
                {
                    User = null,
                    Token = null,
                    Message = "Contraseña incorrecta"

                });
            }

            var token = GenerateToken(user);

            return Ok(
                    new AuthenticationResponse
                    {
                        Token = token,
                        User = user,

                    }
                );

        }



        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWTSetting").GetSection("SecurityKey").Value!);

            List<Claim> claims =
                [
                    new (JwtRegisteredClaimNames.Email,user.Email ?? ""),
                    new (JwtRegisteredClaimNames.Name,user.UserName ?? ""),
                    new (JwtRegisteredClaimNames.NameId, user.Id.ToString() ?? ""),
                    new (JwtRegisteredClaimNames.Aud,_configuration.GetSection("JWTSetting").GetSection("ValidAuidence").Value!),
                    new (JwtRegisteredClaimNames.Iss,_configuration.GetSection("JWTSetting").GetSection("ValidIssuer").Value!),


                ];

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        [HttpGet("user"), Authorize]
        public async Task<ActionResult<AuthenticationResponse>> GetUserInfo()
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (UserId != null)
            {
                var user = await _userManager.FindByIdAsync(UserId);
                return Ok(new { user });

            }

        return BadRequest(ModelState);

        }


    }

}
