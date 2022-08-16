using MediatR;
using System;

namespace Projeto.Base.BackEnd.Application.Commands.Estadio
{
    public class DeletarEstadioCommand : IRequest
    {
        public DeletarEstadioCommand(int estadioId)
        {
            EstadioId = estadioId;
            DataExclusao = DateTime.Now;
        }

        public int EstadioId { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
