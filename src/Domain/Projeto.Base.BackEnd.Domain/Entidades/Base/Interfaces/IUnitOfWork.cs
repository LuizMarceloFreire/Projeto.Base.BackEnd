using System;

namespace Projeto.Base.BackEnd.Domain.Entidades.Base.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
