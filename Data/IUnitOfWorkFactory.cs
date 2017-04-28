using System.Data;

namespace TeamSL.Infrastructure.Data
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(IsolationLevel isolationLevel);
        IUnitOfWork Create();
    }
}
