using BussinesLogicLayer.Abstract;
using Bussiness.Concrete;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using GuzellikSalonuInterfaces.Abstract;
using GuzellikSalonuInterfaces.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy//localhost1880/ gibi kodu buraya yaz�cam https://localhost:7256
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                           .AllowAnyOrigin();
                      });
});


//JWT Kurulumu Yapt���m Yer
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience =true, //olu�turulacak token de�erini kimlerin/hangi origin/sitelerin kullanaca��n� belirliyoruz...
            ValidateIssuer =true,//Tokeni kimin da��tt�n� ifade eder  => www.GuzellikSalonu.com
            ValidateLifetime =true,//Tokenin Ya�am d�ng�s�
            ValidateIssuerSigningKey =true, //�retilecek tokenin bizim uygulamam�za �zg� bir key tan�mlad���m�z yer...


            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:IssuerSigningKey"])),
            ClockSkew =TimeSpan.Zero
        };
    });
// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITokenHandler, GuzellikSalonuInterfaces.Concrete.TokenHandler>();
builder.Services.AddScoped<GuzellikSalonuDbContext, GuzellikSalonuDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


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
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
