using DAL;
using DAL.Interfaces;
using Database;
using Database.Settings;
using DTO.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Repository;
using WebApp.Controllers;
using WebApp.Mappers;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var dbsettings = builder.Configuration.GetSection("DatabaseSettings").Get<DbSettings>();

builder.Services.AddDbContext<UrlShortnerDbContext>(options =>
{
    options.UseSqlServer(dbsettings.ConnectionString);
});

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(IAsyncUnitOfWork<>), typeof(UnitOfWorkBase<>));
builder.Services.AddScoped<ILinkService, LinkService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddFluentValidation(s =>
{
    s.RegisterValidatorsFromAssemblyContaining<ShortLinkCreateRequestValidator>();
    s.DisableDataAnnotationsValidation = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();