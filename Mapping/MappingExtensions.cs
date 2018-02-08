using System.Collections.Generic;
using AutoMapper;

namespace TeamSL.Infrastructure.Mapping
{
    public static class MappingExtensions
    {
        public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper, IList<TSource> source)
        {
            return mapper.Map<IList<TSource>, List<TDestination>>(source);
        }
    }
}