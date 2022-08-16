using MediatR;
using Projeto.Base.BackEnd.Application.ValueObjects;
using System;

namespace Projeto.Base.BackEnd.Application.Commands.Clube
{
    public class CadastrarClubeCommand : IRequest
    {
        public CadastrarClubeCommand(string nome, int anoFundacao, string urlRedeSocial, EstadioVO estadio)
        {
            Nome = nome;
            AnoFundacao = anoFundacao;
            UrlRedeSocial = urlRedeSocial;
            Ativo = true;
            DataInclusao = DateTime.Now;
            Estadio = estadio;
        }

        public string Nome { get; set; }
        public int AnoFundacao { get; set; }
        public string UrlRedeSocial { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public EstadioVO Estadio { get; set; }
    }
}
