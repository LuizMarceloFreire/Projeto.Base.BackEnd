using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios;

namespace Projeto.Base.BackEnd.Infra.Contexto.Mapping
{
    public class EstadioMapping : IEntityTypeConfiguration<Estadio>
    {
        public void Configure(EntityTypeBuilder<Estadio> builder)
        {
            builder.HasKey(e => e.Id).IsClustered(false);

            builder.Property(e => e.Nome).IsRequired().HasMaxLength(200);

            builder.Property(e => e.Pais).IsRequired().HasMaxLength(200);

            builder.Property(e => e.Ativo);

            builder.Property(e => e.DataInclusao).IsRequired();

            builder.Property(e => e.DataAlteracao);

            builder.Property(e => e.DataExclusao);            

            builder.Ignore(t => t.ValidationResult);
            builder.Ignore(t => t.CascadeMode);
            builder.Ignore(t => t.ClassLevelCascadeMode);
            builder.Ignore(t => t.RuleLevelCascadeMode);

            builder.ToTable(nameof(Estadio));
        }
    }
}
