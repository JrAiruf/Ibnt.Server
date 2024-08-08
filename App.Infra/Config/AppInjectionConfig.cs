using App.Application.Interfaces;
using App.Infra.Data;
using App.Infra.Repositories;
using App.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace App.Infra.Config
{
    public static class AppInjectionConfig
    {
        public static WebApplicationBuilder Inject(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<IbntDbContext>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IMembersRepository, MembersRepository>();
            builder.Services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
            builder.Services.AddScoped<ITimeLineRepository, TimeLineRepository>();
            builder.Services.AddScoped<IEventsRepository, EventsRepository>();
            builder.Services.AddScoped<IBibleMessagesRepository, BibleMessagesRepository>();
            builder.Services.AddScoped<IReactionsRepository, ReactionsRepository>();
            builder.Services.AddScoped<IAnnouncementsRepository, AnnouncementsRepository>();
            builder.Services.AddScoped<IHashService, HashService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<RestClient>();

            return builder;
        }
    }
}
