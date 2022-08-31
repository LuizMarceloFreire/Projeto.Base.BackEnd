using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Projeto.Base.BackEnd.Api.Configuration;
using Projeto.Base.BackEnd.Domain.Entidades.Base.Interfaces;
using Projeto.Base.BackEnd.Domain.Entidades.Clubes.Interfaces;
using Projeto.Base.BackEnd.Infra;
using Projeto.Base.BackEnd.Infra.Repositorio;
using Projeto.Base.BackEnd.Services;

namespace Projeto.Base.BackEnd.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ResolveDependencies();

            services.UsarServicesHandlers()
                    .UsarModeloDbContext(Configuration);

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddControllers().AddNewtonsoftJson();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projeto.Base.BackEnd.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke();
                var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                unitOfWork.Commit();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto.Base.BackEnd.Api v1"));

                app.UseHttpsRedirection();

                app.UseCors(x => x.AllowAnyHeader()
                                  .AllowAnyOrigin()
                                  .AllowAnyMethod());
            }

            app.UseHttpsRedirection();

            app.UseRouting();            

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
