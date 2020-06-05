using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SamaraOrganicsSystem.Data;
using SamaraOrganicsSystem.Dtos;
using SamaraOrganicsSystem.Models;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration Config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            Config = config;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto Dto)
        {
            if(await _repo.UserExists(Dto.Email))
            {
                return BadRequest("User already Exists");
            }
            else
            {
                var userToCreate = new Users
                {
                    PersonFk = Dto.PersonFk,
                    UserRoleFk = Dto.UserRoleFk
                };
                await _repo.Register(userToCreate, Dto.Password);
                return StatusCode(201);

            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Email.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.IdUser.ToString()),
                new Claim(ClaimTypes.Name, userForLoginDto.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });

        }
    }
}