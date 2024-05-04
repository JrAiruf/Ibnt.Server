using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Config
{
    public static class ApiConfiguration
    {
        public static string HOST = Environment.GetEnvironmentVariable("PGHOST");
        public static string PASSWORD = Environment.GetEnvironmentVariable("PGPASSWORD");
        public static string USER = Environment.GetEnvironmentVariable("PGUSER");
        public static string PORT = Environment.GetEnvironmentVariable("PGPORT");

        public static string ConnectionStringValue()
        {
            return $"host={HOST}:{PORT};userid={USER};password={PASSWORD}";
            //return "datasource=ibntDb";
        }

        public static void ApplyMigrations(IbntDbContext context)
        {
            if(context.Database.EnsureCreated())
            {
                return;
            }
            else
            {
                context.Database.Migrate();
            }
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
