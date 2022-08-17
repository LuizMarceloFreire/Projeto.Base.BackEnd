using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Estadio
{
    public class DeletarEstadioHandler : AsyncRequestHandler<DeletarEstadioCommand>
    {
        private readonly IEstadioRepositorio _repositorio;

        public DeletarEstadioHandler(IEstadioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        protected override async Task Handle(DeletarEstadioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var estadio = await _repositorio.ObterPorIdAsync(request.EstadioId);

                if (estadio == null)
                    throw new Exception("Nenhum estádio encontrado.");

                estadio.Excluir();
                _repositorio.Atualizar(estadio);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
