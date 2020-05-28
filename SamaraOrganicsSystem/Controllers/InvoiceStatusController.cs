using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Data;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceStatusController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public InvoiceStatusController( SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        // GET: api/InvoiceStatus
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var statusList = await _db.InvoiceStatus.ToListAsync();
            if(statusList != null)
            {
                return Ok(statusList);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/InvoiceStatus/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/InvoiceStatus
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/InvoiceStatus/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
