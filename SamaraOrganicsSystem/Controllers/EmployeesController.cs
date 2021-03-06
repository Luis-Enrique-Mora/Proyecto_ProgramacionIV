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
    public class EmployeesController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public EmployeesController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        // GET: api/UserEmployees
        [HttpGet("getemployees")]
        public async Task<IActionResult> Index()
        {
            var employeesList = await _db.Employee.ToListAsync();
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
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get (int id)
        {
            var findEmployee = await _db.Employee.FirstOrDefaultAsync(emp => emp.EmployeeId == id);
            if (findEmployee != null)
            {
                return Ok(findEmployee);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
