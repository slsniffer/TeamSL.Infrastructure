using System;

namespace TeamSL.Infrastructure.Domain.Caching
{
    public class CacheQueryAttribute : Attribute
    {
        public int Ttl { get; set; }

        /// <summary>
        /// Default constructor with default time to live of 5 hours.
        /// </summary>
        public CacheQueryAttribute()
        {
            Ttl = 60*60*5;
        }

        /// <summary>
        /// Cache attribute for query entity.
        /// </summary>
        /// <param name="ttl">Time to live in seconds.</param>
        public CacheQueryAttribute(int ttl)
        {
            Ttl = ttl;
        }
    }
}