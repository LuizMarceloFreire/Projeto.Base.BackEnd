using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto.Base.BackEnd.Services
{
    public static class Bootstrapper
    {
        public static IServiceCollection UsarServicesHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(Bootstrapper).Assembly);
        }
    }
}
