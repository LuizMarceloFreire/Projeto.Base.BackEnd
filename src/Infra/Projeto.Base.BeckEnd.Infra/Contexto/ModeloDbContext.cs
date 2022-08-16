using Microsoft.EntityFrameworkCore;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes;

namespace Projeto.Base.BackEnd.Infra.Contexto
{
    public class ModeloDbContext : DbContext
    {
        public ModeloDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModeloDbContext).Assembly);
        }

        public DbSet<Clube> Clube { get; set; }

        public DbSet<Estadio> Estadio { get; set; }
    }
}
