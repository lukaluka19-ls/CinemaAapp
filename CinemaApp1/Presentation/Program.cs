using CinemaApp1.Application.Mapping;
using CinemaApp1.Application.Services.Implementation;
using CinemaApp1.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

builder.Services.ConfigureInfrastructure(builder.Configuration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)),
        ClockSkew = TimeSpan.Zero
    };
});

//var hasher = new CinemaApp1.Application.Services.Implementation.PasswordHashService();
//Console.WriteLine(hasher.Hash("Admin123!"));
//    return;

builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

//builder.Services.AddHttpsRedirection(options => {
//    options.HttpsPort = 443;
//});


var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Title = "CinemaApp1 API Reference";
    options.Theme = ScalarTheme.BluePlanet;
    //options.Description = "API reference for CinemaApp1";
    //options.Version = "v1.0";
    options.CustomCss = "";
}

);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();