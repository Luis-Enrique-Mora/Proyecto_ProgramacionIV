using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Data;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorsController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public VendorsController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var vendorsList = await _db.Vendors
                .Select(v => new { 
                    v.VendorId, 
                    v.PersonFkNavigation.PersonName, 
                    v.PersonFkNavigation.LastName, 
                    v.PersonFkNavigation.Phones }).ToListAsync();
            
            if(vendorsList.Count > 0)
            {
                return Ok(vendorsList);
            }

            return NotFound("We couldn't find any Vendor.");
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var vendor = await _db.Vendors.
                Select(v => new { 
                    v.VendorId, 
                    v.PersonFkNavigation.PersonName,
                    v.PersonFkNavigation.LastName, 
                    v.PersonFkNavigation.Phones })
                .FirstOrDefaultAsync();
            if(vendor != null)
            {
                return Ok(vendor);
            }

            return BadRequest("Sorry, but we couldn't find the vendor");
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var exists = await _db.Vendors.Where(v => v.VendorId == id).FirstOrDefaultAsync();
            
            if(exists != null)
            {
                _db.Vendors.Remove(exists);
                await _db.SaveChangesAsync();
                return Ok("Vendor deleted");
            }
            return BadRequest("Something went wrong, seems like the invoice does not exists");
        }

    }
}