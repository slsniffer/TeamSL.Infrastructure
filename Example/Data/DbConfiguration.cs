namespace TeamSL.Infrastructure.Example.Data
{
    public interface IDbConfiguration
    {
        string DatabaseName { get; }
    }

    public class DbConfiguration : IDbConfiguration
    {
        public string DatabaseName => "test.db";
    }
}