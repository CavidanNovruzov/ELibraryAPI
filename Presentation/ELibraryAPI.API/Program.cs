using ELibraryAPI.Persistance;
using ELibraryAPI.Application;
using ELibraryAPI.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options=>options.Filters.Add<>())
    .AddFluentValidion(Configuration=>Configuration.RegistrValidatorsFromAssemblyContaining<>())
    .ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter = true);
builder.Services.AddHttpContextAccessor();

// Program.cs
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistanceServices();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.WithOrigins().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true, //yaradılcaq token dəyərini kimin dağıtacağını ifadə edir
            ValidateAudience = true,  //yaradılacaq token dəyərini kimlərin/hansı originlərin istifadə edə biləcəyini təyin edir
            ValidateLifetime = true, //yaradılacaq token dəyərinin müddətinin bitib-bitmədiyini yoxlayır    
            ValidateIssuerSigningKey = true, //yaradılacaq token dəyərinin imzalanmasında istifadə olunan gizli anahtarın doğruluğunu yoxlar
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
