using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Data;
using SamaraOrganicsSystem.Dtos;
using SamaraOrganicsSystem.Models;
using SamaraOrganicsSystem.Models.ViewModels;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoicesController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public InvoicesController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var invoiceList = await _db.Invoices
              .Select(i => new {
                i.InvoiceId,
                i.InvoiceNumber,
                i.InvoiceDate,
                i.VendorFkNavigation.VendorName,
                i.InvoiceCategoryFkNavigation.CategoryName,
                i.StatusFkNavigation.StatusName,
                i.InvoiceAmount,
                i.MoneyAccountFkNavigation.NameMoneyAccount})
              .ToListAsync();

            if(invoiceList != null)
            {
                return Ok(invoiceList);
            }
            else
            {
                return NotFound("Not invoices found..");
            }
        }

        [HttpGet]
        [Route("get/create")]
        public async Task<IActionResult> GetCreate()
        {

            CreateInvoiceVM VM = new CreateInvoiceVM()
            {
                VendorList = await (from vend in _db.Vendors 
                                    select new VendorDto{ id = vend.VendorId, name = vend.VendorName}).ToListAsync(),
                CategoryList = await (from cat in _db.InvoiceCategory 
                                    select new CategoryDto { id = cat.InvoiceCategoryId, CategoryName = cat.CategoryName}).ToListAsync(),
                StatusList = await (from Status in _db.InvoiceStatus 
                                    select new StatusDto{id = Status.StatusId, StatusName = Status.StatusName}).ToListAsync(),
                AccountsList = await (from Accounts in _db.MoneyAccounts 
                                    select new AccountsDto {id = Accounts.MoneyAccountId, AccountName = Accounts.NameMoneyAccount}).ToListAsync()
            };

            if(VM != null)
            {
                return Ok(VM);
            }

            return NotFound("Couldn't get info to create a new invoice");
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var findInvoice = await _db.Invoices.Where(i => i.InvoiceId == id)
                .Select( i=> new {
                    i.InvoiceId,
                    i.InvoiceNumber,
                    i.InvoiceDate, 
                    i.InvoiceCategoryFkNavigation.CategoryName, 
                    i.InvoiceDescription,
                    i.InvoiceAmount,
                    i.StatusFkNavigation.StatusName, 
                    i.MoneyAccountFkNavigation.NameMoneyAccount, 
                    i.FinalPayment })
                .FirstOrDefaultAsync();

            if(findInvoice != null)
            {
                return Ok(findInvoice);
            }
            else
            {
                return NotFound("Sorry, seems like the invoice does not exists");
            }
        }

        [HttpGet]
        [Route("getedit/{id}")]
        public async Task<IActionResult> edit(int? id)
        {
            var findInvoice = await _db.Invoices.Where(i => i.InvoiceId == id)
                .Select(i => new {
                    i.InvoiceId,
                    i.InvoiceNumber,
                    i.InvoiceDate,
                    i.InvoiceCategoryFkNavigation.CategoryName,
                    i.InvoiceDescription,
                    i.InvoiceAmount,
                    i.StatusFkNavigation.StatusName,
                    i.MoneyAccountFkNavigation.NameMoneyAccount,
                    i.FinalPayment
                })
                .FirstOrDefaultAsync();
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult>Create(Invoices invoice)
        {
            bool exists = CheckIfExists(invoice);
            if (!exists)
            {
                _db.Add(invoice);
                await _db.SaveChangesAsync();
                return Ok("Invoice saved successfully");
            }

            return BadRequest("Seems like the invoice already exists");
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var invoice = await _db.Invoices.Where(i => i.InvoiceId == id).FirstOrDefaultAsync();
            if (invoice != null)
            {
               _db.Invoices.Remove(invoice);
                await _db.SaveChangesAsync();
                return Ok("The invoice have been deleted");

            }

            return NotFound("Seems like the invoice does not exists");
        }

        public bool CheckIfExists(Invoices invoice)
        {
            var check = _db.Invoices.Where(
                i => i.InvoiceNumber == invoice.InvoiceNumber && 
                i.InvoiceDate == invoice.InvoiceDate && 
                i.VendorFk == invoice.VendorFk);

            if(check == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}