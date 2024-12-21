using Microsoft.EntityFrameworkCore;
using Kuafor_Sistemi.Models;

var builder = WebApplication.CreateBuilder(args);

// DbContext'i DI'ye kaydediyoruz ve baðlantý dizesini burada saðlýyoruz
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC'yi ekliyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

