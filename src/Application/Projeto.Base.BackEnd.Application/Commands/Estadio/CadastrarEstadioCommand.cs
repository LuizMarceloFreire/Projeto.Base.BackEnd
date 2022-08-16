using MediatR;
using System;

namespace Projeto.Base.BackEnd.Application.Commands.Estadio
{
    public class CadastrarEstadioCommand : IRequest
    {
        public CadastrarEstadioCommand(string nome, string pais, bool ativo)
        {
            Nome = nome;
            Pais = pais;
            Ativo = ativo;
            DataInclusao = DateTime.Now;
        }

        public string Nome { get; set; }
        public string Pais { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
