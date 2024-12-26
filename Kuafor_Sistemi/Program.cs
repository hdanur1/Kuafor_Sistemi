using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Kuafor_Sistemi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// DbContext'i DI'ye kaydediyoruz ve baðlantý dizesini burada saðlýyoruz
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Giriþ yapmayan kullanýcýyý yönlendirme yolu
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Session özelliði ekleniyor
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
    options.Cookie.HttpOnly = true; // Çerezlere yalnýzca HTTP üzerinden eriþilebilir
    options.Cookie.IsEssential = true; // GDPR uyumluluðu için gerekli
});

// MVC'yi ekliyoruz
builder.Services.AddControllersWithViews();

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
        c.RoutePrefix = "swagger"; // Swagger UI sadece /swagger adresinde eriþilebilir
    });
}

// ** Doðru middleware sýralamasý **
app.UseRouting(); // UseRouting middleware, UseEndpoints'ten önce çaðrýlmalý

app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization(); // Yetkilendirme
app.UseSession(); // Session middleware

app.UseStaticFiles(); // Statik dosyalar için middleware

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // API controller'lar için
    endpoints.MapDefaultControllerRoute(); // MVC rotalarý için
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
