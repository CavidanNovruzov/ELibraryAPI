using ELibraryAPI.API.Extensions;
using ELibraryAPI.API.Middlewares;
using ELibraryAPI.Application;
using ELibraryAPI.Application.Options;
using ELibraryAPI.Infrastructure;
using ELibraryAPI.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog; 
using System.Text;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("ELibraryAPI is starting up...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithThreadId());    


    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddPersistanceServices();

    builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
        policy.WithOrigins("https://libraff.az").AllowAnyHeader().AllowAnyMethod()));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Elibrary API", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Tokeni bura daxil edin (Bearer sözünə ehtiyac yoxdur)"
        });
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                new string[]{}
            }
        });
    });

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.Events.OnRedirectToLogin = ctx =>
        { ctx.Response.StatusCode = StatusCodes.Status401Unauthorized; return Task.CompletedTask; };
        options.Events.OnRedirectToAccessDenied = ctx =>
        { ctx.Response.StatusCode = StatusCodes.Status403Forbidden; return Task.CompletedTask; };
    });

    builder.Services.AddAuthorization();
    builder.Services.Configure<SeedOptions>(builder.Configuration.GetSection(SeedOptions.SectionName));

    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        JwtOptions? jwtTokenOption = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
        if (jwtTokenOption == null || string.IsNullOrWhiteSpace(jwtTokenOption.SecretKey))
            throw new Exception("JWT config is missing");

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = jwtTokenOption.Audience,
            ValidIssuer = jwtTokenOption.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOption.SecretKey)),
            ClockSkew = TimeSpan.Zero,
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
            {
                return expires != null && expires > DateTime.UtcNow;
            }
        };
    });

    var app = builder.Build();


    app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        await app.SeedDataAsync();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly.");
}
finally
{
    Log.CloseAndFlush();
}