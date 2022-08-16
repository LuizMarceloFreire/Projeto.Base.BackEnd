using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Clube;
using Projeto.Base.BackEnd.Application.ValueObjects;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Clube
{
    public class BuscarClubePorIdHandler : IRequestHandler<BuscarClubePorIdCommand, ClubeVO>
    {
        private readonly IClubeRepositorio _repositorio;
        public BuscarClubePorIdHandler(IClubeRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ClubeVO> Handle(BuscarClubePorIdCommand request, CancellationToken cancellationToken)
        {
            var clube = await _repositorio.ObterPorIdAsync(request.ClubeId);

            var retornoClubeVo = new ClubeVO
            {
                Id = clube.Id,
                Nome = clube.Nome,
                AnoFundacao = clube.AnoFundacao,
                Ativo = clube.Ativo,
                DataInclusao = clube.DataInclusao,
                Estadio = new EstadioVO
                {
                   Id = clube.Estadio.Id,
                   Nome = clube.Estadio.Nome,
                   Pais = clube.Estadio.Pais,
                   Ativo = clube.Estadio.Ativo,
                   DataInclusao = clube.Estadio.DataInclusao
                }
            };

            return retornoClubeVo;
        }
    }
}
