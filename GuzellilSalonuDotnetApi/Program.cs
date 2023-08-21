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
//                   opts.ExpireTimeSpan = TimeSpan.FromDays(14);  //Burada cookie'nin ömrünü belirliyoruz...
//                   opts.SlidingExpiration = false; // Burayý false vererek Kullanýcýnýn 14 gün sonra zorla tekrardan þifreyle vs login olmasýný saðlýyoruz.. true verirsek her girdiðinde süreye 14 gün ekler...
//                   opts.LoginPath = "/Kullanici/GirisYap"; //Burada Kullanýcý Login Deðilse Direk Tanýmladýðýmýz controller'ýn Action'nýna gidiyor.
//                                                           // opts.LogoutPath = "/Kullanici/CikisYap"; // Burayý daha tanýmlamadým tanýmlanýcak...!!!
//                                                           //opts.AccessDeniedPath = "/Home/Anasayfa"; //Burasýda Yetki olmadýðý zaman gideceði yer ben burayý kullanmayý düþünmüyorum silerim ileride...
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
