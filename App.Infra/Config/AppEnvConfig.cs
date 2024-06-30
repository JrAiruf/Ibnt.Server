using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace App.Infra.Config
{
    public static class AppEnvConfig
    {
        public static WebApplicationBuilder EnviromentConfig(this WebApplicationBuilder builder)
        {
            string? port = Environment.GetEnvironmentVariable("PORT");
            builder.WebHost.UseUrls($"http://*[::1]:{port}");

            return builder;
        }
    }
}
