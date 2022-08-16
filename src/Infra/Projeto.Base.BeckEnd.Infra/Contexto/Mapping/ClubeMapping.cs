using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes;

namespace Projeto.Base.BackEnd.Infra.Contexto.Mapping
{
    public class ClubeMapping : IEntityTypeConfiguration<Clube>
    {
        public void Configure(EntityTypeBuilder<Clube> builder)
        {
            builder.HasKey(e => e.Id).IsClustered(false);

            builder.Property(e => e.Nome).IsRequired().HasMaxLength(200);

            builder.Property(e => e.AnoFundacao).IsRequired();

            builder.Property(e => e.UrlRedeSocial).IsRequired();

            builder.Property(e => e.Ativo);

            builder.Property(e => e.DataInclusao).IsRequired();

            builder.Property(e => e.DataAlteracao);

            builder.Property(e => e.DataExclusao);

            builder.HasOne(e => e.Estadio)
                    .WithOne(p => p.Clube)
                    .HasForeignKey<Clube>(e => e.EstadioId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(t => t.ValidationResult);
            builder.Ignore(t => t.CascadeMode);
            builder.Ignore(t => t.ClassLevelCascadeMode);
            builder.Ignore(t => t.RuleLevelCascadeMode);


            builder.ToTable(nameof(Clube));
        }
    }
}
