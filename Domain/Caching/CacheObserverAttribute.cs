using System;

namespace TeamSL.Infrastructure.Domain.Caching
{
    public class CacheObserverAttribute : Attribute
    {
        public Type[] Commands { get; set; }

        public CacheObserverAttribute(params Type[] commands)
        {
            Commands = commands ?? new Type[0];
        }
    }
}