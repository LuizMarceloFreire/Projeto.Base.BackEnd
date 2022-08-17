using Projeto.Base.BackEnd.Application.ValueObjects.Base;
using System;

namespace Projeto.Base.BackEnd.Application.ValueObjects
{
    public class EstadioVO : BaseVO
    {
        public string Nome { get; set; }
        public string Pais { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataExclusao { get; set; }
        public ClubeVO Clube { get; set; }
    }
}