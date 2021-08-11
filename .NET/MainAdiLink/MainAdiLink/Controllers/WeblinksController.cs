using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainAdiLink.Models;

namespace MainAdiLink.Controllers
{
    public class WeblinksController : Controller
    {
        private readonly WeblinksContext _context;

        public WeblinksController(WeblinksContext context)
        {
            _context = context;
        }

        // GET: Weblinks
        public async Task<IActionResult> Index(string searchString)
        {
            var weblinks = from m in _context.Weblinks
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                weblinks = weblinks.Where(s => s.NameOfLink.Contains(searchString));
            }

            return View(await weblinks.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Weblinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var weblink = await _context.Weblinks
                .Include(w => w.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(weblink);
        }

        // GET: Weblinks/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Weblinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Weblink weblink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weblink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", weblink.CategoryId);
            return View(weblink);
        }

        // GET: Weblinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var weblink = await _context.Weblinks.FindAsync(id);

            /*ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", weblink.CategoryId);*/
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", weblink.CategoryId);
            return View(weblink);
        }

        // POST: Weblinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Weblink weblink)
        {
            if (id != weblink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weblink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeblinkExists(weblink.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", weblink.CategoryId);
            return View(weblink);
        }

        // GET: Weblinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var weblink = await _context.Weblinks
                .Include(w => w.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(weblink);
        }

        // POST: Weblinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weblink = await _context.Weblinks.FindAsync(id);
            _context.Weblinks.Remove(weblink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeblinkExists(int id)
        {
            return _context.Weblinks.Any(e => e.Id == id);
        }

        public async Task<IActionResult> FavoriteToggle(FavoriteToggleViewModel model)
        {
            // find entity in db
            var weblink = await _context.Weblinks.FindAsync(model.WebLinkId);
            // change entity
            weblink.IsFavorite = !weblink.IsFavorite;
            // mark entity as modified
            _context.Entry(weblink).State = EntityState.Modified;
            // save changes in db
            await _context.SaveChangesAsync();

            // return answer to frontend
            return Ok(); // 200
            //return BadRequest(); //400
        }

    }
}
