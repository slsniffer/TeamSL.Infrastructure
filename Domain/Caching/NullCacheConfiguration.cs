namespace TeamSL.Infrastructure.Domain.Caching
{
    public class NullCacheConfiguration : ICacheConfiguration
    {
        public bool IsEnabled => false;
    }
}