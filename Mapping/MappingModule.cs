using Autofac;
using Autofac.Features.ResolveAnything;
using AutoMapper;

namespace TeamSL.Infrastructure.Mapping
{
    public class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => c.Resolve<IMappingConfigurator>().Configure().CreateMapper(c.Resolve<IComponentContext>().Resolve)).As<IMapper>();

            var assembly = typeof(MappingModule).Assembly;
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IMappingAction<,>)).AsSelf();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        }
    }

}