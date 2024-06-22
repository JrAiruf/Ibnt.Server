using Ibnt.Server.Application.Interfaces;
using Ibnt.Server.Infra.Config;
using Ibnt.Server.Infra.Data;
using Ibnt.Server.Infra.Repositories;
using Ibnt.Server.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestSharp;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IbntDbContext>();

var context = builder.Configuration.Get<IbntDbContext>();

if (context != null)
{
    ApiConfiguration.ApplyMigrations(context);
}

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<IMembersRepository, MembersRepository>();

builder.Services.AddScoped<ITimeLineRepository, TimeLineRepository>();

builder.Services.AddScoped<IEventsRepository, EventsRepository>();

builder.Services.AddScoped<IBibleMessagesRepository, BibleMessagesRepository>();

builder.Services.AddScoped<IReactionsRepository, ReactionsRepository>();

builder.Services.AddScoped<IHashService, HashService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<RestClient>();

var port = Environment.GetEnvironmentVariable("PORT");
builder.WebHost.UseUrls($"http://*[::1]:{port}");

var secretKey = Encoding.ASCII.GetBytes(Secrets.SecretKey!);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<String>()
        }
    });
});

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
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

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
