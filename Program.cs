using Microsoft.EntityFrameworkCore;
using TutorialWindowsMVC.Data;
using TutorialWindowsMVC.Data.Services;

namespace TutorialWindowsMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FinanceAppContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
            //One instance per request 
            builder.Services.AddScoped<IExpensesService, ExpensesService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //This is the route specified for the program
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
