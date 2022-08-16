using Projeto.Base.BackEnd.Application.ValueObjects.Base;
using System;

namespace Projeto.Base.BackEnd.Application.ValueObjects
{
    public class ClubeVO : BaseVO
    {
        public string Nome { get; set; }
        public int AnoFundacao { get; set; }
        public string UrlRedeSocial { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataExclusao { get; set; }
        public EstadioVO Estadio { get; set; }
    }
}
