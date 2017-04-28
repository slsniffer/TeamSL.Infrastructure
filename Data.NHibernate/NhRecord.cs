using System;
using NHibernate;

namespace TeamSL.Infrastructure.Data.NHibernate
{
    public class NhRecord : Record
    {
        public override Type GetRealType()
        {
            return NHibernateUtil.GetClass(this);
        }
    }
}