using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using log4net;
using Module = Autofac.Module;

namespace TeamSL.Infrastructure.Tools.Logging
{
    public class LoggingModule : Module
    {
        private readonly string _loggerName;

        public LoggingModule(string loggerName)
        {
            _loggerName = loggerName;
            GlobalContext.Properties["LoggerName"] = _loggerName;
        }

        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<Log4NetLoggerFactory>().As<ILoggerFactory>();
            moduleBuilder.Register(CreateLogger).As<ILogger>();
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            var implementationType = registration.Activator.LimitType;

            // build an array of actions on this type to assign loggers to member properties
            var injectors = BuildLoggerInjectors(implementationType).ToArray();

            // if there are no logger properties, there's no reason to hook the activated event
            if (!injectors.Any())
                return;

            // otherwise, whan an instance of this component is activated, inject the loggers on the instance
            registration.Activated += (s, e) => {
                foreach (var injector in injectors)
                    injector(e.Context, e.Instance);
            };
        }

        private IEnumerable<Action<IComponentContext, object>> BuildLoggerInjectors(Type componentType)
        {
            // Look for settable properties of type "ILogger" 
            var loggerProperties = componentType
                .GetProperties(BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new {
                    PropertyInfo = p,
                    p.PropertyType,
                    IndexParameters = p.GetIndexParameters(),
                    Accessors = p.GetAccessors(false)
                })
                .Where(x => x.PropertyType == typeof(ILogger)) // must be a logger
                .Where(x => !x.IndexParameters.Any()) // must not be an indexer
                .Where(x => x.Accessors.Length != 1 || x.Accessors[0].ReturnType == typeof(void)); //must have get/set, or only set

            // Return an array of actions that resolve a logger and assign the property
            foreach (var entry in loggerProperties)
            {
                var propertyInfo = entry.PropertyInfo;

                yield return (ctx, instance) => {
                    string component = componentType.ToString();
                    if (component != instance.GetType().ToString())
                    {
                        return;
                    }
                    var logger = ctx.Resolve<ILogger>(new TypedParameter(typeof(Type), componentType));
                    propertyInfo.SetValue(instance, logger, null);
                };
            }
        }

        private ILogger CreateLogger(IComponentContext context, IEnumerable<Parameter> parameters)
        {
            var loggerFactory = context.Resolve<ILoggerFactory>();
            return loggerFactory.Create(_loggerName);
        }
    }
}