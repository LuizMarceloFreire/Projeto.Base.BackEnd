using MediatR;
using System;

namespace Projeto.Base.BackEnd.Application.Commands.Clube
{
    public class DeletarClubeCommand : IRequest
    {
        public DeletarClubeCommand(int clubeId)
        {
            ClubeId = clubeId;
            DataExclusao = DateTime.Now;
        }

        public int ClubeId { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
