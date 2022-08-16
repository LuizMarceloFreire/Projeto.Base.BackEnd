using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Base.BackEnd.Domain.Entidades.Base
{
    public abstract class Entidade <TId, TEntity> : AbstractValidator<TEntity> where TId : struct where TEntity : Entidade<TId, TEntity>
    {
        public TId Id { get; protected set; }
        public DateTime DataInclusao { get; protected set; }
        public DateTime? DataAlteracao { get; protected set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool Validar();

        protected Entidade()
        {
           Id = default(TId);
           DataInclusao = DateTime.Now;
           ValidationResult = new ValidationResult();
        }
    }
}
