using MainAdiLink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MainAdiLink.Controllers
{
    public class HomeController : Controller
    {
        private WeblinksContext db;
        public HomeController(WeblinksContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Weblinks.Include(x => x.Category).ToListAsync());
        }
    }
}
