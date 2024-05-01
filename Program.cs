using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Infra.Data;
using Ibnt.Server.Infra.Repositories;
using Ibnt.Server.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<IbntDbContext>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<IMembersRepository, MembersRepository>();

builder.Services.AddScoped<IEventsRepository, EventsRepository>();

builder.Services.AddScoped<IReactionsRepository, ReactionsRepository>();

builder.Services.AddScoped<IHashService, HashService>();

builder.Services.AddScoped<ITokenService, TokenService>();

void ApplyMigrations(IbntDbContext context)
{
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

var secretKey = Encoding.ASCII.GetBytes(Secrets.SecretKey);
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(
    jwt =>
    {
        jwt.RequireHttpsMetadata = false;
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    opt =>
    {
        opt.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });


var port = Environment.GetEnvironmentVariable("RAILWAY_TCP_APPLICATION_PORT") ?? "8081";
builder.WebHost.UseUrls($"http://localhost:{port}");

ApplyMigrations(new IbntDbContext());

app.UseAuthorization();

app.MapControllers();

app.Run();
