using Azure.Messaging;
using LandCaster.BLL.ILogic;
using LandCaster.DAL;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;


namespace LandCaster.BLL.Logic
{
    public class AuthLogic 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> _userManager;

        public AuthLogic(UserManager<User> userManager, UserManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        //public async Task<ActionResult<AuthenticationResponse>> Login(Credentials credentials)
        //{
        //    var resultado = await signInManager.PasswordSignInAsync(credentials.Email,
        //        credentials.Password, isPersistent: false, lockoutOnFailure: false);

        //    if (resultado.Succeeded)
        //    {
        //        var user = await _userManager.FindByEmailAsync(credentials.Email);
        //        return await ConstruirToken(credentials, user.Id);
        //    }
        //    else
        //    {
        //        return new AuthenticationResponse()
        //        {
        //            Token = null
        //        };
        //    }
        //}

        //private async Task<AuthenticationResponse> ConstruirToken(Credentials credentials, string userId)
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim("email", credentials.Email),
        //        new Claim("id", userId)
        //    };

        //    var user = await _userManager.FindByEmailAsync(credentials.Email);
        //    var claimsDB = await _userManager.GetClaimsAsync(user);

        //    claims.AddRange(claimsDB);

        //    var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llavejwt"]));
        //    var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

        //    var expiration = DateTime.UtcNow.AddYears(1);

        //    var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
        //        expires: expiration, signingCredentials: creds);

        //    return new AuthenticationResponse()
        //    {
        //        Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
        //        Expiration = expiration
        //    };
        //}

    }
}
 