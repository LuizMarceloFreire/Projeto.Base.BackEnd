using System;

namespace Projeto.Base.BackEnd.Application.ValueObjects.Base
{
    public class BaseVO
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
