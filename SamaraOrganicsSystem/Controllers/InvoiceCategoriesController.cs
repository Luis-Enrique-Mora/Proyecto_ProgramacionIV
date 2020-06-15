using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Data;
using SamaraOrganicsSystem.Models;

namespace SamaraOrganicsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceCategoriesController : ControllerBase
    {
        private readonly SamaraOrganicsServerContext _db;
        public InvoiceCategoriesController(SamaraOrganicsServerContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var CategoriesList = await _db.InvoiceCategory.Select(Cat => new { Cat.InvoiceCategoryId, Cat.CategoryName }).ToListAsync();

            if (CategoriesList != null)
            {
                return Ok();
            }
            else
            {
                return NotFound("Sorry, we couldn't find categories for you!");

            }
        }

        public bool Exists(string categoryName)
        {
            var checkExistence = _db.InvoiceCategory.Where(a => a.CategoryName.ToLower() == categoryName.ToLower());

            if (checkExistence.Count() > 0)
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
        public async Task<IActionResult> GetCategory(int? id)
        {
            var category = await _db.InvoiceCategory.Select(Cat => new { Cat.InvoiceCategoryId, Cat.CategoryName, Cat.CategoryDescription }).ToListAsync();

            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound("The Category wasn't found");
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(InvoiceCategory category)
        {
            if (!Exists(category.CategoryName))
            {
                _db.InvoiceCategory.Add(category);
                await _db.SaveChangesAsync();
                return Ok("Category saved");
            }

            return BadRequest("Sorry something went wrong");
        }
        public bool SearchCategory(int? id)
        {
            var find = _db.InvoiceCategory.Where(i=> i.InvoiceCategoryId == id).FirstOrDefault();
            if(find != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditCategory(InvoiceCategory category)
        {
            if (SearchCategory(category.InvoiceCategoryId))
            {
                var categoryFromDB = await _db.InvoiceCategory.FindAsync(category.InvoiceCategoryId);
                categoryFromDB.CategoryName = category.CategoryName;
                categoryFromDB.CategoryDescription = category.CategoryDescription;

                await _db.SaveChangesAsync();
                return Ok("Changes saved");
            }

            return BadRequest("Sorry, we coudn't complete the update");
        }

        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (SearchCategory(id))
            {
                var categoryFromDB = await _db.InvoiceCategory.Where(c => c.InvoiceCategoryId == id).FirstOrDefaultAsync();
                _db.InvoiceCategory.Remove(categoryFromDB);

                await _db.SaveChangesAsync();
                return Ok("The category has been deleted successfully");
            }

            return BadRequest("Sorry, we couldn't delete the category, it was not found");
        }
        
    }

}