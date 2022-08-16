using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Clube;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Clube
{
    public class CadastrarClubeHandler : AsyncRequestHandler<CadastrarClubeCommand>
    {
        private readonly IClubeRepositorio _repositorio;

        public CadastrarClubeHandler(IClubeRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        protected async override Task Handle(CadastrarClubeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clube = new Domain.Entidades.Clubes.Clube(request.Nome, request.AnoFundacao, request.UrlRedeSocial, request.Ativo);
                await _repositorio.AdicionarAsync(clube);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
    }
}
