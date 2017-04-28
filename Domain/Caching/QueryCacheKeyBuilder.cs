using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TeamSL.Infrastructure.Domain.Caching
{
    public interface IQueryCacheKeyBuilder
    {
        string Build(object query);
    }

    public class QueryCacheKeyBuilder : IQueryCacheKeyBuilder
    {
        private static readonly IDictionary<string, PropertyInfo[]> _cacheKeyedPropertyInfos = new Dictionary<string, PropertyInfo[]>();

        public string Build(object query)
        {
            var queryType = query.GetType();

            var sb = new StringBuilder("QUERY_" + queryType.Name);

            if (!_cacheKeyedPropertyInfos.ContainsKey(queryType.FullName))
            {
                var properties = queryType.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public);
                var cacheProperties = properties.Where(propertyInfo => propertyInfo.GetCustomAttribute<CacheKeyAttribute>() != null).ToArray();

                _cacheKeyedPropertyInfos.Add(queryType.FullName, cacheProperties);
            }

            foreach (var propertyInfo in _cacheKeyedPropertyInfos[queryType.FullName])
            {
                sb.AppendFormat("_{0}:{1}", propertyInfo.Name, propertyInfo.GetValue(query));
            }

            return sb.ToString();
        }
    }
}