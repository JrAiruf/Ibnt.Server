namespace Ibnt.Server.Infra.Services
{
    public static class Secrets
    {
        public static string? SecretKey = Environment.GetEnvironmentVariable("SECRET_KEY");
    }
}
