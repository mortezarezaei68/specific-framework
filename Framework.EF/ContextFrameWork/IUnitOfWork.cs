using System;

namespace Framework.EF.ContextFrameWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}