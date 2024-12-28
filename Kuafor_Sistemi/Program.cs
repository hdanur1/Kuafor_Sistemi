using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Kuafor_Sistemi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Kuafor_Sistemi.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext'i DI'ye kaydediyoruz ve ba�lant� dizesini burada sa�l�yoruz
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Giri� yapmayan kullan�c�y� y�nlendirme yolu
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Session �zelli�i ekleniyor
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum s�resi
    options.Cookie.HttpOnly = true; // �erezlere yaln�zca HTTP �zerinden eri�ilebilir
    options.Cookie.IsEssential = true; // GDPR uyumlulu�u i�in gerekli
});


// MVC'yi ekliyoruz
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<KullaniciService>();
builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "KuaforYonetim API v1");
        c.RoutePrefix = "swagger"; // Swagger UI sadece /swagger adresinde eri�ilebilir
    });
}



app.UseRouting(); // Y�nlendirme middleware'i

app.UseAuthentication(); // Kimlik do�rulama middleware'i
app.UseAuthorization(); // Yetkilendirme middleware'i, authentication'dan sonra gelir

app.UseSession(); // Oturum middleware'i

app.UseStaticFiles(); // Statik dosyalar middleware'i

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // API controller'lar i�in
    endpoints.MapDefaultControllerRoute(); // MVC rotalar� i�in
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
