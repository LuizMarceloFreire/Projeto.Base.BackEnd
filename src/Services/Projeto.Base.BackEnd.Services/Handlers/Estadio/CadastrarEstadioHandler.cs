using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Estadio
{
    public class CadastrarEstadioHandler : AsyncRequestHandler<CadastrarEstadioCommand>
    {
        private readonly IEstadioRepositorio _repositorio;

        public CadastrarEstadioHandler(IEstadioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        protected async override Task Handle(CadastrarEstadioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var estadio = new Domain.Entidades.Estadios.Estadio(request.Nome, request.Pais, request.Ativo);
                await _repositorio.AdicionarAsync(estadio);                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
