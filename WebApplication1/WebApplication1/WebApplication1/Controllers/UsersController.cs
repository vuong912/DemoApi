using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Services;
using WebApplication1.Dtos;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService userService;
        private readonly IConfiguration config;
        public UsersController(IUserService userService,IConfiguration config)
        {
            this.userService = userService;
            this.config = config;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IEnumerable<UserDto>> Get()
        {
            // return db.Accounts.AsQueryable().ToList();
            return await userService.Get();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            var user = await userService.Login(login);
            if (user != null)
            {
                return Ok(new { token = BuildToken(user) });
            }
            return Unauthorized();
        }

        private string BuildToken(UserDto user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                new Claim(ClaimTypes.Role,userService.Permission(user.Permission)),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}