using MediatR;
using System;

namespace Projeto.Base.BackEnd.Application.Commands.Estadio
{
    public class EditarEstadioCommand : IRequest
    {
        public EditarEstadioCommand(int estadioId, string nome, string pais, bool ativo)
        {
            EstadioId = estadioId;
            Nome = nome;
            Pais = pais;
            Ativo = ativo;
            DataAlteracao = DateTime.Now;
        }

        public int EstadioId { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
