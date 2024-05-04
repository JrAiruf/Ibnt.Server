using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Config
{
    public class ApiConfiguration
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
            if (context.Database.EnsureCreated() && !context.Database.GetPendingMigrations().Any())
            {
                return;
            }
            else
            {
                context.Database.Migrate();
            }
        }
    }
}

