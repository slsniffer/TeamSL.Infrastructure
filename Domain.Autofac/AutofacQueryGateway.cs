using System;
using System.Linq;
using Autofac;
using TeamSL.Infrastructure.Domain.Queries;

namespace TeamSL.Infrastructure.Domain.Autofac
{
    public class AutofacQueryGateway : IQueryGateway
    {
        private readonly IComponentContext _resolver;

        public AutofacQueryGateway(IComponentContext resolver)
        {
            _resolver = resolver;
        }

        public TResult Read<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>);

            var handler = GetHandler(handlerType, query);

            if (handler == null)
                throw new QueryHandlerNotFoundException(handlerType);

            if (handlerType.GetMethods().Length > 1)
                throw new Exception($"Query handler [{handlerType.FullName}] has more than one method.");

            var method = handlerType.GetMethods().First();

            return (TResult)handler.GetType().GetMethod(method.Name).Invoke(handler, new object[] { query });
        }

        private object GetHandler<TResult>(Type handlerType, IQuery<TResult> query)
        {
            var resultType = typeof(TResult);
            var queryType = query.GetType();

            var customType = handlerType.MakeGenericType(queryType, resultType);

            return _resolver.Resolve(customType);
        }
    }
}