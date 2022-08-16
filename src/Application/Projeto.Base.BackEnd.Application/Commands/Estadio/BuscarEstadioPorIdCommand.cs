using MediatR;
using Projeto.Base.BackEnd.Application.ValueObjects;

namespace Projeto.Base.BackEnd.Application.Commands.Estadio
{
    public class BuscarEstadioPorIdCommand : IRequest<EstadioVO>
    {
        public BuscarEstadioPorIdCommand(int estadioId)
        {
            EstadioId = estadioId;
        }

        public int EstadioId { get; set; }
    }
}
