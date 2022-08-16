using MediatR;
using Projeto.Base.BackEnd.Application.ValueObjects;
using System.Collections.Generic;

namespace Projeto.Base.BackEnd.Application.Commands.Clube
{
    public class ListarClubeCommand : IRequest<List<ClubeVO>>
    {
    }
}
