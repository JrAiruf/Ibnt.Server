using Ibnt.Server.Infra.Data;

namespace Ibnt.Server.Infra.Config
{
    public interface IApiConfiguration
    {
        public string ConnectionStringValue();
        public void ApplyMigrations();
    }
}
