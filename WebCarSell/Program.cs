using Microsoft.EntityFrameworkCore;
using WebCarSell.BusinessLogic.Extensions;
using WebCarSell.DataAccess.Context;
using WebCarSell.DataAccess.Entities;
using WebCarSell.Extentions;
using WEBCarSell.BusinessLogic.Interfaces;
using WEBCarSell.BusinessLogic.Services;
using WEBCarSell.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile), typeof(AutoMapperViewProfile));

builder.Services.AddScoped<IRepository, GenericRepository>();
builder.Services.AddScoped<ICarSellService, CarSellService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
