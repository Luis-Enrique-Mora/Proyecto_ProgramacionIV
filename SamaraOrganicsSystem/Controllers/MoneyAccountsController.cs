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
    public class MoneyAccountsController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public MoneyAccountsController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var AccountsList = await _db.MoneyAccounts.Select(a => new { a.MoneyAccountId, a.NameMoneyAccount, a.DescriptionMoneyAccount }).ToListAsync();

            if(AccountsList.Count > 0)
            {
                return Ok(AccountsList);
            }

            return NotFound("Sorry, We couldn't find any Account");
        }
    }
}