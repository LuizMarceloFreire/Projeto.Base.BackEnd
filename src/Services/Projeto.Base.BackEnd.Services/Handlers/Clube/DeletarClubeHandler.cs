using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Clube;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Clube
{
    public class DeletarClubeHandler : AsyncRequestHandler<DeletarClubeCommand>
    {
        private readonly IClubeRepositorio _repositorio;

        public DeletarClubeHandler(IClubeRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        protected override async Task Handle(DeletarClubeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clube = await _repositorio.ObterPorIdAsync(request.ClubeId);

                if (clube == null)
                    throw new Exception("Nenhum estádio encontrado.");

                clube.Excluir();
                _repositorio.Atualizar(clube);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
