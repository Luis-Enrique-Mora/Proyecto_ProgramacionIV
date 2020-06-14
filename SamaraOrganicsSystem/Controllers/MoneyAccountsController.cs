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

        public bool SearchAccount(int? id)
        {
            var find = _db.MoneyAccounts.Where(m => m.MoneyAccountId == id).FirstOrDefault();
            if (find != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetAccount(int? id)
        {
            var account = await _db.MoneyAccounts.Where(a => a.MoneyAccountId == id)
                .Select(a => new {
                a.MoneyAccountId, 
                a.NameMoneyAccount, 
                a.DescriptionMoneyAccount })
                .FirstOrDefaultAsync();

            if(account != null)
            {
                return Ok(account);
            }

            return NotFound("Sorrry, we could not find this Account");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAccount(int? id)
        {
            if (SearchAccount(id))
            {
                var Account = await _db.MoneyAccounts.Where(a => a.MoneyAccountId == id).FirstOrDefaultAsync();
                _db.Remove(Account);
                await _db.SaveChangesAsync();
                return Ok("Account deleted");
            }

            return BadRequest("Sorry, we couldn't delete the account");
        }
    }
}