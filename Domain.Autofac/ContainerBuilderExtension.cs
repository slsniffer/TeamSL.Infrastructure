using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace TeamSL.Infrastructure.Domain.Autofac
{
    public static class ContainerBuilderExtension
    {
        public static void RegisterGenericHandlers(this ContainerBuilder builder, Assembly assembly, Type handlerType, string key)
        {
            builder.RegisterAssemblyTypes(assembly)
                .As(type => type.GetInterfaces()
                    .Where(interfaceType => interfaceType.IsClosedTypeOf(handlerType))
                    .Select(interfaceType => new KeyedService(key, interfaceType)))
                .PropertiesAutowired();
        }
    }
}