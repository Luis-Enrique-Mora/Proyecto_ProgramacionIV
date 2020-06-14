using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Data;
using SamaraOrganicsSystem.Models;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        public bool Exists(string AccountName)
        {
            var checkExistence = _db.MoneyAccounts.Where(a => a.NameMoneyAccount.ToLower() == AccountName.ToLower());

            if (checkExistence.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(MoneyAccounts Account)
        {
            if (!Exists(Account.NameMoneyAccount))
            {
                _db.Add(Account);
                await _db.SaveChangesAsync();
                return Ok("The account was saved successfully");
            }

            return BadRequest("Sorry, seems like the Account already exists, or filed at the time to inster");
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(MoneyAccounts account)
        {
            if (SearchAccount(account.MoneyAccountId))
            {

            }
            return Ok("Updated");
        }

        [HttpPost]
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