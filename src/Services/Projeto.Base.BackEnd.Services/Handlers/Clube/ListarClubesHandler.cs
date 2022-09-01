using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Clube;
using Projeto.Base.BackEnd.Application.ValueObjects;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Clube
{
    public class ListarClubesHandler : IRequestHandler<ListarClubeCommand, List<ClubeVO>>
    {
        private readonly IClubeRepositorio _repositorio;

        public ListarClubesHandler(IClubeRepositorio repositorio)
        {
            _repositorio = repositorio; 
        }

        public async Task<List<ClubeVO>> Handle(ListarClubeCommand request, CancellationToken cancellationToken)
        {
            var clubes = await _repositorio.BuscarAsync(x => x.DataExclusao == null);
            var retornoLista = new List<ClubeVO>();

            foreach (var clube in clubes)
            {
                var clubeVO = new ClubeVO()
                {
                    Id = clube.Id,
                    Nome = clube.Nome,
                    AnoFundacao = clube.AnoFundacao,
                    Ativo = clube.Ativo,
                    UrlRedeSocial = clube.UrlRedeSocial,
                    DataAlteracao = clube.DataAlteracao,
                    DataInclusao = clube.DataInclusao,
                    DataExclusao = clube.DataExclusao,
                };

                retornoLista.Add(clubeVO);
            }

            return retornoLista;
        }
    }
}
