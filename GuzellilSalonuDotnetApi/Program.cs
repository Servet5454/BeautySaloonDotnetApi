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
                          policy//localhost1880/ gibi kodu buraya yazýcam https://localhost:7256
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                           .AllowAnyOrigin();
                      });
});


//JWT Kurulumu Yaptýðým Yer
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience =true, //oluþturulacak token deðerini kimlerin/hangi origin/sitelerin kullanacaðýný belirliyoruz...
            ValidateIssuer =true,//Tokeni kimin daðýttýný ifade eder  => www.GuzellikSalonu.com
            ValidateLifetime =true,//Tokenin Yaþam döngüsü
            ValidateIssuerSigningKey =true, //Üretilecek tokenin bizim uygulamamýza özgü bir key tanýmladýðýmýz yer...


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
