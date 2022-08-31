using Microsoft.EntityFrameworkCore;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using Projeto.Base.BackEnd.Infra.Contexto;
using Projeto.Base.BackEnd.Infra.Repositorio.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Infra.Repositorio
{
    public class ClubeRepositorio : RepositorioBase<int, Clube>, IClubeRepositorio
    {
        private readonly ModeloDbContext _context;
        public ClubeRepositorio(ModeloDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Clube> ObterPorIdComIncludeEstadioAsync(int id)
        {
            var clube = await _context.Clube.Where(x => x.Id == id).Include(x => x.Estadio).FirstOrDefaultAsync();

            if (clube == null)
                throw new Exception("Nenhum clube encontrado.");

            return clube;
        }
    }
}
