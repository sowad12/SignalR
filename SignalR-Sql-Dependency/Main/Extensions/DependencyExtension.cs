using Library.Context;
using Library.Infrastructer.Implementation;
using Library.Infrastructer.Interface;
using Library.Infrastructer.Options;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Manager.Interface;
using Main.Manager.Implementation;

namespace Main.Extensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddDependency(this IServiceCollection services,
  IConfiguration configuration)
        {
            try
            {
                services.AddSignalR();
                //versioning dependency
                var apiVersioningBuilder = services.AddApiVersioning(o =>
                {
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new ApiVersion(1, 0);
                    o.ReportApiVersions = true;
                    o.ApiVersionReader = ApiVersionReader.Combine(
                        new QueryStringApiVersionReader("api-version"),
                        new HeaderApiVersionReader("X-Version"),
                        new MediaTypeApiVersionReader("ver"));
                });
                services.AddScoped<ISession>(provider =>
            provider
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext
                .Session);

                services.AddScoped<ISystemManager, SystemManager>();
                services.AddScoped<IProductManager, ProductManager>();
            }
            catch (Exception ex)
            {
                throw;
            }
            return services;
        }
    }
}
