using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Infra.Repositorio.Interfaces
{
    public interface IReadOnlyRepositoryAsync<in TId, TEntity>
        where TId : struct
        where TEntity : class
    {
        Task<TEntity> ObterPorIdAsync(TId id);
        Task<IEnumerable<TEntity>> ListarAsync();
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
