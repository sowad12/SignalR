using Library.Context;
using Library.Infrastructer.Implementation;
using Library.Infrastructer.Interface;
using Library.Infrastructer.Options;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Manager.Interface;
using Main.Manager.Implementation;
using Main.Hubs;
using Main.SqlTableDependency;
using TableDependency.SqlClient;
using Microsoft.AspNetCore.SignalR.Client;

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
                //services.AddSingleton<HubConnection>(provider =>
                //{
                //    var hubConnection = new HubConnectionBuilder()
                //        .WithUrl("/dashboardHub")
                //        .Build();
                //    return hubConnection;
                //});

                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });
                });
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
                services.AddSingleton<DashboardHub>();
                services.AddScoped<ProductTable>();
             
                //services.AddScoped<ISqlTableDependency, ProductTable>();

            }
            catch (Exception ex)
            {
                throw;
            }
            return services;
        }
    }
}
