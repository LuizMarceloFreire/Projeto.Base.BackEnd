using MediatR;
using Projeto.Base.BackEnd.Application.ValueObjects;

namespace Projeto.Base.BackEnd.Application.Commands.Clube
{
    public class BuscarClubePorIdCommand : IRequest<ClubeVO>
    {
        public BuscarClubePorIdCommand(int clubeId)
        {
            ClubeId = clubeId;  
        }

        public int ClubeId { get; set; }
    }
}
