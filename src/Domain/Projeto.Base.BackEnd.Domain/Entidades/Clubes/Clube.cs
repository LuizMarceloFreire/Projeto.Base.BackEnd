using FluentValidation;
using Projeto.Base.BackEnd.Domain.Entidades.Base;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios;
using System;

namespace Projeto.Base.BackEnd.Domain.Entidades.Clubes
{
    public class Clube : Entidade<int, Clube>
    {
        protected Clube(){}

        public Clube(string nome, int anoFundacao, string urlRedeSocial, bool ativo)
        {
            Nome = nome;
            AnoFundacao = anoFundacao;
            UrlRedeSocial = urlRedeSocial;
            Ativo = ativo;
            DataInclusao = DateTime.Now;
        }

        public int EstadioId { get; private set; }
        public string Nome { get; private set; }
        public int AnoFundacao { get; private set; }
        public string UrlRedeSocial { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime? DataExclusao { get; private set; }

        //Ef Relation
        public virtual Estadio Estadio { get; private set; }

        public override bool Validar()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(200)
                .NotNull();

            RuleFor(x => x.AnoFundacao)
                .NotEqual(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UrlRedeSocial)
                .NotEmpty()
                .MaximumLength(100)
                .NotNull();

            RuleFor(x => x.DataInclusao)
                .NotEmpty()
                .NotNull();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarAnoFundacao(int anoFundacao)
        {
            AnoFundacao = anoFundacao;
        }

        public void AlterarUrlRedeSocial(string urlRedeSocial)
        {
            UrlRedeSocial = urlRedeSocial;
        }

        public void AlterarDataAlteracao(DateTime? dataAlteracao)
        {
            DataAlteracao = dataAlteracao;
        }

        public void AlterarSituacao(bool ativo)
        {
            Ativo = ativo;
        }

        public void Excluir()
        {
            DataExclusao = DateTime.Now;
        }
    }
}
