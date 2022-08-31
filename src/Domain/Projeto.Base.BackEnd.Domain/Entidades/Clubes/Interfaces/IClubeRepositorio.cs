using Projeto.Base.BackEnd.Domain.Entidades.Base.Interfaces;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces
{
    public interface IClubeRepositorio : IRepositorioBase<int, Clube>
    {
        Task<Clube> ObterPorIdComIncludeEstadioAsync(int id);
    }
}
