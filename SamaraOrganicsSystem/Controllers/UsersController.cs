using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Data;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public UsersController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        // GET: api/Users/index
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var Users = await _db.Users.ToListAsync();
            return Ok(Users);
        }

    }
}
