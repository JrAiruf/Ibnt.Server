using App.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Infra.Config
{
    public static class AppContextConfig
    {
        public static string? HOST = Environment.GetEnvironmentVariable("PGHOST");
        public static string? PASSWORD = Environment.GetEnvironmentVariable("PGPASSWORD");
        public static string? USER = Environment.GetEnvironmentVariable("PGUSER");
        public static string? PORT = Environment.GetEnvironmentVariable("PGPORT");
        public static string? DATABASE = Environment.GetEnvironmentVariable("PGDATABASE");

        public static string ConnectionStringValue()
        {
            return $"host={HOST}:{PORT};userid={USER};password={PASSWORD};Database={DATABASE}";
        }
        public static WebApplicationBuilder Migrate(this WebApplicationBuilder builder)
        {
            IbntDbContext? context = builder.Configuration.Get<IbntDbContext>();
            if (context != null)
            {
                    context.Database.Migrate();
            }
            return builder;
        }
    }
}
