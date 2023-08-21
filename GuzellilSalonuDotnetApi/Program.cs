using BussinesLogicLayer.Abstract;
using Bussiness.Concrete;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<GuzellikSalonuDbContext, GuzellikSalonuDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//builder.Services
//               .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//               .AddCookie(opts =>
//               {
//                   opts.Cookie.Name = ".GuzellikSalonu";
//                   opts.ExpireTimeSpan = TimeSpan.FromDays(14);  //Burada cookie'nin �mr�n� belirliyoruz...
//                   opts.SlidingExpiration = false; // Buray� false vererek Kullan�c�n�n 14 g�n sonra zorla tekrardan �ifreyle vs login olmas�n� sa�l�yoruz.. true verirsek her girdi�inde s�reye 14 g�n ekler...
//                   opts.LoginPath = "/Kullanici/GirisYap"; //Burada Kullan�c� Login De�ilse Direk Tan�mlad���m�z controller'�n Action'n�na gidiyor.
//                                                           // opts.LogoutPath = "/Kullanici/CikisYap"; // Buray� daha tan�mlamad�m tan�mlan�cak...!!!
//                                                           //opts.AccessDeniedPath = "/Home/Anasayfa"; //Buras�da Yetki olmad��� zaman gidece�i yer ben buray� kullanmay� d���nm�yorum silerim ileride...
//               });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
