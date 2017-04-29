namespace TeamSL.Infrastructure.Example
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