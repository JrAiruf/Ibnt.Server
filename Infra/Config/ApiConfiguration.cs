using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Config
{
    public class ApiConfiguration
    {
        public static string? HOST = Environment.GetEnvironmentVariable("PGHOST");
        public static string? PASSWORD = Environment.GetEnvironmentVariable("PGPASSWORD");
        public static string? USER = Environment.GetEnvironmentVariable("PGUSER");
        public static string? PORT = Environment.GetEnvironmentVariable("PGPORT");

        public static string ConnectionStringValue()
        {
            HOST = HOST ?? "localhost";
            PASSWORD = PASSWORD ?? "12345678";
            USER = USER ?? "jradmin";
            PORT = PORT ?? "41357";
            return $"host={HOST}:{PORT};userid={USER};password={PASSWORD}";
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

    