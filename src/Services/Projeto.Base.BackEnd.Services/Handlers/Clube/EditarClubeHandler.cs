using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Clube;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Clube
{
    public class EditarClubeHandler : AsyncRequestHandler<EditarClubeCommand>
    {
        private readonly IClubeRepositorio _repositorio;

        public EditarClubeHandler(IClubeRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        protected override async Task Handle(EditarClubeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clube = await _repositorio.ObterPorIdAsync(request.ClubeId);

                if (clube == null)
                    throw new Exception("Nenhum clube encontrado.");

                clube.AlterarNome(request.Nome);
                clube.AlterarAnoFundacao(request.AnoFundacao);
                clube.AlterarUrlRedeSocial(request.UrlRedeSocial);
                clube.AlterarDataAlteracao(request.DataAlteracao);
                clube.AlterarSituacao(request.Ativo);

                _repositorio.Atualizar(clube);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
