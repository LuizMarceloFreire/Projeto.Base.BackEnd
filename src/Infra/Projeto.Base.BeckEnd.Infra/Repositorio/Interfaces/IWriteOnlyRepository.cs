using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Infra.Repositorio.Interfaces
{
    public interface IWriteOnlyRepository<in TEntity>
        where TEntity : class
    {
        Task AdicionarAsync(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
    }
}
