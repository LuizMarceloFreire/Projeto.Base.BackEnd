using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Domain.Entidades.Base.Interfaces
{
    public interface IRepositorioBase<TId, TEntity>
    {
        Task AdicionarAsync(TEntity obj);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> ListarAsync();
        Task<TEntity> ObterPorIdAsync(TId id);
        void Atualizar(TEntity obj);
    }
}
