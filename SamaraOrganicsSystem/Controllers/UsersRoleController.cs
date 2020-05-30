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
    public class UsersRoleController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public UsersRoleController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        // GET: api/UsersRole/index
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var rolesList = await _db.UserRole.Select(role => new {role.UserRoleId, role.RoleName, role.RoleDescription }).ToListAsync();

            if (rolesList != null)
            {
                return Ok(rolesList);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
