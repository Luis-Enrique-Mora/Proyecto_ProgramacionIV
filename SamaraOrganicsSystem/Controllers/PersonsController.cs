using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Data;
using SamaraOrganicsSystem.Models;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public PersonsController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        // GET: api/Persons/index
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var PersonsList = await _db.Persons.ToListAsync();

            if (PersonsList != null)
            {
                return Ok(PersonsList);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Persons/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var findPerson = await _db.Persons.FirstOrDefaultAsync(per => per.IdPerson == id);

            if(findPerson != null)
            {
                return Ok(findPerson);
            }
            else
            {
                return NotFound();
            }
        }

       
    }
}
