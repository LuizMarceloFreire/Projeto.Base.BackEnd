using MediatR;
using Projeto.Base.BackEnd.Application.ValueObjects;
using System.Collections.Generic;

namespace Projeto.Base.BackEnd.Application.Commands.Estadio
{
    public class ListarEstadioCommand : IRequest<List<EstadioVO>>
    {
    }
}
