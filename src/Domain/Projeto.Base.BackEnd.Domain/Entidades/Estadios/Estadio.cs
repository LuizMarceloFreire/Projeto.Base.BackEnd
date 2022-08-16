using FluentValidation;
using Projeto.Base.BackEnd.Domain.Entidades.Base;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes;
using System;

namespace Projeto.Base.BackEnd.Domain.Entidades.Estadios
{
    public class Estadio : Entidade<int, Estadio>
    {
        protected Estadio()
        {
        }

        public Estadio(string nome, string pais, bool ativo)
        {
            Nome = nome;
            Pais = pais;
            Ativo = ativo;
            DataInclusao = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Pais { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime? DataExclusao { get; private set; }

        //EF Relation
        public virtual Clube Clube { get; private set; }

        public override bool Validar()
        {
            RuleFor(x => x.Nome)
               .NotEmpty()
               .MaximumLength(200)
               .NotNull();

            RuleFor(x => x.Pais)
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

        public void AlterarPais(string pais)
        {
            Pais = pais;
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
