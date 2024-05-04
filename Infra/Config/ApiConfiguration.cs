using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Config
{
    public class ApiConfiguration : IApiConfiguration
    {
        private readonly IbntDbContext _context;
        public ApiConfiguration(IbntDbContext context)
        {
            _context = context;
        }
        public static string HOST = Environment.GetEnvironmentVariable("PGHOST");
        public static string PASSWORD = Environment.GetEnvironmentVariable("PGPASSWORD");
        public static string USER = Environment.GetEnvironmentVariable("PGUSER");
        public static string PORT = Environment.GetEnvironmentVariable("PGPORT");

        public string ConnectionStringValue()
        {
            return $"host={HOST}:{PORT};userid={USER};password={PASSWORD}";
            //return "datasource=ibntDb";
        }

        public void ApplyMigrations()
        {
            if (_context.Database.EnsureCreated() && !_context.Database.GetPendingMigrations().Any())
            {
                return;
            }
            else

                _context.Database.Migrate();
        }
    }
}

