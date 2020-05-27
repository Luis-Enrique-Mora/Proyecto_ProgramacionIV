﻿using System;
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
    public class UserEmployeesController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public UserEmployeesController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        // GET: api/UserEmployees
        [HttpGet("getemployees")]
        public async Task<IActionResult> Index()
        {
            var employeesList = await _db.UserEmployee.ToListAsync();
            if (employeesList != null)
            {
                return Ok(employeesList);
            }
            else 
            {
                return NotFound();
            }
        }

        // GET: api/findemployee/5
        [HttpGet("{id}",Name ="findemployee")]
        public async Task<IActionResult> Get (int id)
        {
            var findEmployee = await _db.UserEmployee.FirstOrDefaultAsync(emp => emp.EmployeeId == id);
            if (findEmployee != null)
            {
                return Ok(findEmployee);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/UserEmployees
        [HttpPost]
        public void Post()
        {
        }

        // PUT: api/UserEmployees/5
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
