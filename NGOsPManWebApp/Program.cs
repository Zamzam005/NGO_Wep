using Microsoft.EntityFrameworkCore;
using NGOsPManWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    // pattern: "{controller=Home}/{action=Index}/{id
    pattern: "{controller=Adver}/{action=Index}/{id?}");

app.Run();
