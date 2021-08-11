using MainAdiLink.ActionFilters;
using MainAdiLink.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace MainAdiLink
{ 
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = "Server = (localdb)\\mssqllocaldb; Database = weblinkstoredb; Trusted_Connection=true";
            services.AddDbContext<WeblinksContext>(options =>
                options.UseSqlServer(connection));
            services.AddControllersWithViews(options => {
                options.Filters.Add<LayoutViewBagActionFilter>();
            });
        }
 
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
 
            app.UseRouting();
 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
            /*app.UseHttpsRedirection();

            app.UseAuthorization();*/
    }
}
