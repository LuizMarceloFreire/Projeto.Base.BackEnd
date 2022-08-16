using Projeto.Base.BackEnd.Domain.Entidades.Estadios;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using Projeto.Base.BackEnd.Infra.Contexto;
using Projeto.Base.BackEnd.Infra.Repositorio.Base;

namespace Projeto.Base.BackEnd.Infra.Repositorio
{
    public class EstadioRepositorio : RepositorioBase<int, Estadio>, IEstadioRepositorio
    {
        private readonly ModeloDbContext _context;
        public EstadioRepositorio(ModeloDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
