using Microsoft.EntityFrameworkCore;
using Projeto.Base.BackEnd.Domain.Entidades.Base;
using Projeto.Base.BackEnd.Infra.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Infra.Repositorio.Base
{
    public class RepositorioBase<TId, TEntity> :
        IReadOnlyRepositoryAsync<TId, TEntity>,
        IWriteOnlyRepository<TEntity>
        where TId : struct
        where TEntity : Entidade<TId, TEntity>
    {
        private readonly DbSet<TEntity> _dbSet;

        public RepositorioBase(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task AdicionarAsync(TEntity obj) => await _dbSet.AddAsync(obj);

        public void Atualizar(TEntity obj) => _dbSet.Update(obj);

        public void Remover(TEntity obj) => _dbSet.Remove(obj);

        public async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

        public async Task<IEnumerable<TEntity>> ListarAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> ObterPorIdAsync(TId id) => await _dbSet.FindAsync(id);

        //public async Task Salvar() => await _dbSet.SaveChanges();
    }
}
