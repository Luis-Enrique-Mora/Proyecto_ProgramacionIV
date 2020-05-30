using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
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
    }
}