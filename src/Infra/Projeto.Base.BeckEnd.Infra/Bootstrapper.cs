using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.BackEnd.Infra.Contexto;

namespace Projeto.Base.BackEnd.Infra
{
    public static class Bootstrapper
    {
        public static IServiceCollection UsarModeloDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ModeloDbContext>(config => config.UseSqlServer(configuration.GetConnectionString("ModeloDatabase")));
        }
    }
}
