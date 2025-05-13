using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TFMS.Models;
using Transportation_fleet_management_system.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Transportation_fleet_management_systemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Transportation_fleet_management_systemContext") ?? throw new InvalidOperationException("Connection string 'Transportation_fleet_management_systemContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext configuration here:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // This sets up the routing middleware

app.UseAuthorization();

app.UseEndpoints(endpoints => // Add this block
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // If you are using attribute routing on your DriversController,
    // this default route will still allow access based on those attributes.
    // If you want to rely solely on conventional routing for DriversController,
    // you would add a specific route here:
    //
    // endpoints.MapControllerRoute(
    //     name: "drivers",
    //     pattern: "Drivers/{action=Index}/{id?}");
    //
    // Or for singular "Driver":
    //
    // endpoints.MapControllerRoute(
    //     name: "driver",
    //     pattern: "Driver/{action=Index}/{id?}");
});

app.Run();