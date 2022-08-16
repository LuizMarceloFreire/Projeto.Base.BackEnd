using MediatR;
using Projeto.Base.BackEnd.Application.Commands.Estadio;
using Projeto.Base.BackEnd.Application.ValueObjects;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.BackEnd.Services.Handlers.Estadio
{
    public class BuscarEstadioPorIdHandler : IRequestHandler<BuscarEstadioPorIdCommand, EstadioVO>
    {
        private readonly IEstadioRepositorio _repositorio;
        public BuscarEstadioPorIdHandler(IEstadioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<EstadioVO> Handle(BuscarEstadioPorIdCommand request, CancellationToken cancellationToken)
        {
            var estadio = await _repositorio.ObterPorIdAsync(request.EstadioId);

            var retornoEstadioVo = new EstadioVO
            {
                    Id = estadio.Id,
                    Nome = estadio.Nome,
                    Pais = estadio.Pais,
                    Ativo = estadio.Ativo,
                    DataInclusao = estadio.DataInclusao
            };

            return retornoEstadioVo;
        }
    }
}
