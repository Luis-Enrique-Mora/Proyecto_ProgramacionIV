using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public class InvoiceStatusController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public InvoiceStatusController( SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        // GET: api/InvoiceStatus/index
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var findStatus = await _db.InvoiceStatus.Where(status => status.StatusId == id)
                            .Select(status => new { status.StatusId, status.StatusName, status.StatusDescription }).ToListAsync();
            if(findStatus != null)
            {
                return Ok(findStatus);
            }
            else
            {
                return NotFound();
            }

        }

        public bool CheckIfExists(string statusName)
        {
            var checkExistence = _db.InvoiceStatus.Where(status => status.StatusName.ToLower() == statusName.ToLower());

            if (checkExistence.Count() > 0)
            {
                return false;
            }
            else 
            {
                return true;
            } 
        }
        // POST: api/InvoiceStatus/insert
        [HttpPost("insert")]
        public async Task<IActionResult> InsertStatus (InvoiceStatus status)
        {
            if(ModelState.IsValid)
            {
                bool exists = CheckIfExists(status.StatusName);

                if (exists)
                {
                    return BadRequest("This status already exists");
                }
                else
                {
                    _db.Add(status);
                    await _db.SaveChangesAsync();
                    return Ok("Invoice Satus saved");
                }
            }
            else
            {
                return BadRequest();
            }
            
        }
        // POST: api/InvoiceStatus/edit
        [HttpPost("edit")]
        public async Task<IActionResult> editStatus(InvoiceStatus Status)
        {
            if(ModelState.IsValid)
            {
                var exists = _db.InvoiceStatus.Where(status => status.StatusId == Status.StatusId);

                if(exists.Count() > 0)
                {
                    var statusFromDB = await _db.InvoiceStatus.FindAsync(Status.StatusId);

                    statusFromDB.StatusName = Status.StatusName;
                    statusFromDB.StatusDescription = Status.StatusDescription;
                    await _db.SaveChangesAsync();
                    return Ok("Saved changes");
                }
                else
                {
                    return BadRequest("Status doesn't exists");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        // POST: api/InvoiceStatus/delete
        [HttpPost("delete")]
        public async Task<IActionResult> deleteStatus(int? id)
        {
            if(id != null)
            {
                var statusToDelete = await _db.InvoiceStatus.FindAsync(id);
                if(statusToDelete != null)
                {
                   _db.InvoiceStatus.Remove(statusToDelete);
                    await _db.SaveChangesAsync();
                    return Ok("Status removed");
                }
                else
                {
                    return NotFound("Couldn't find invoice status");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
