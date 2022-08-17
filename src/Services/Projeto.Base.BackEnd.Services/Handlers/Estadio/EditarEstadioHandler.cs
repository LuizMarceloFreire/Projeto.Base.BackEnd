using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Estadio
{
    public class EditarEstadioHandler : AsyncRequestHandler<EditarEstadioCommand>
    {
        private readonly IEstadioRepositorio _repositorio;
        public EditarEstadioHandler(IEstadioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        protected override async Task Handle(EditarEstadioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var estadio = await _repositorio.ObterPorIdAsync(request.EstadioId);

                if (estadio == null)
                    throw new Exception("Nenhum estádio encontrado.");

                estadio.AlterarNome(request.Nome);
                estadio.AlterarPais(request.Pais);
                estadio.AlterarDataAlteracao(request.DataAlteracao);
                estadio.AlterarSituacao(request.Ativo);

                _repositorio.Atualizar(estadio);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
