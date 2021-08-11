using MainAdiLink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Linq;

namespace MainAdiLink.ActionFilters
{
    public class LayoutViewBagActionFilter : ActionFilterAttribute
    {
        private WeblinksContext db;
        public LayoutViewBagActionFilter(WeblinksContext context)
        {
            db = context;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // for Razor Views
            if (context.Controller is Controller)
            {
                var controller = context.Controller as Controller;

                controller.ViewBag.MenuCategories = db.Categories.ToList(); //Сделать асинхронным

                //also you have access to the httpcontext & route in controller.HttpContext & controller.RouteData
            }

            base.OnResultExecuting(context);
        }
    }
}
