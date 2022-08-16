using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.BackEnd.Domain.Entidades.Base.Interfaces;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using Projeto.Base.BackEnd.Domain.Entidades.Estadios.Interfaces;
using Projeto.Base.BackEnd.Infra.Contexto;
using Projeto.Base.BackEnd.Infra.Repositorio;

namespace Projeto.Base.BackEnd.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IClubeRepositorio, ClubeRepositorio>();
            services.AddScoped<IEstadioRepositorio, EstadioRepositorio>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
