using System;
using NHibernate;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public interface ISessionProvider : IDisposable
    {
        ISession CurrentSession { get; }
    }
}