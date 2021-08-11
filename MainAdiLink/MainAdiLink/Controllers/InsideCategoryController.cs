using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MainAdiLink.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace MainAdiLink.Controllers
{
    public class InsideCategoryController : Controller
    {
        private WeblinksContext db;
        public InsideCategoryController(WeblinksContext context)
        {
            db = context;
        }

        // GET: InsideCategoryController
        public async Task<ActionResult> IndexAsync()
        {
            return View(await db.Weblinks.Include(x => x.Category).ToListAsync());
        }

        public async Task<ActionResult> Details(int id)
        {
            var allLinks = (await db.Weblinks.Where(wl => wl.CategoryId == id).ToListAsync());
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);

            var model = new InsideCategoryDetailsViewModel
            {
                CategoryName = category.CategoryName,
                WebLinks = allLinks
            };

            return View(model);
        }
    }
}
