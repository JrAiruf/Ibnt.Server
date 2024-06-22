using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Config
{
    public class ApiConfiguration
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

        public static void ApplyMigrations(IbntDbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}

    