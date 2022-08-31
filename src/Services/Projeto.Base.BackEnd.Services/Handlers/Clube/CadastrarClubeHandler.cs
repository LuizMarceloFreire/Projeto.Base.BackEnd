using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Clube;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Clube
{
    public class CadastrarClubeHandler : AsyncRequestHandler<CadastrarClubeCommand>
    {
        private readonly IClubeRepositorio _clubeRepositorio;
        private readonly IEstadioRepositorio _estadioRepositorio;

        public CadastrarClubeHandler(IClubeRepositorio clubeRepositorio, IEstadioRepositorio estadioRepositorio)
        {
            _clubeRepositorio = clubeRepositorio;
            _estadioRepositorio = estadioRepositorio;
        }

        protected async override Task Handle(CadastrarClubeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clube = new Domain.Entidades.Clubes.Clube(request.Nome, request.AnoFundacao, request.UrlRedeSocial, request.Ativo);

                var estadio = await _estadioRepositorio.ObterPorIdAsync(request.EstadioId);

                if (estadio == null)
                    throw new Exception("Estádio não encontrado");

                clube.VincularEstadio(estadio);

                await _clubeRepositorio.AdicionarAsync(clube);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
    }
}
