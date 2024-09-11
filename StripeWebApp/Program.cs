namespace StripeWebApp;

using Microsoft.EntityFrameworkCore;
using Stripe;
using StripeWebApp.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<MvcContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<String>();

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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=PaymentController}/{action=Index}/{id?}");

        app.Run();
    }
}
