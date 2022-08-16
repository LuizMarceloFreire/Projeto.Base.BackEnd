using MediatR;
using Projeto.Base.BackEnd.Application.ValueObjects;
using System;

namespace Projeto.Base.BackEnd.Application.Commands.Clube
{
    public class EditarClubeCommand : IRequest
    {
        public EditarClubeCommand(int clubeId, string nome, int anoFundacao, string urlRedeSocial, bool ativo, EstadioVO estadio)
        {
            ClubeId = clubeId;
            Nome = nome;
            AnoFundacao = anoFundacao;
            UrlRedeSocial = urlRedeSocial;
            Ativo = ativo;
            DataAlteracao = DateTime.Now;
            Estadio = estadio;
        }

        public int ClubeId { get; set; }
        public string Nome { get; set; }
        public int AnoFundacao { get; set; }
        public string UrlRedeSocial { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public EstadioVO Estadio { get; set; }
    }
}
