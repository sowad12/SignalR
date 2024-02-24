using Main.SqlTableDependency;

namespace Main.Extensions
{
    public static class SqlTableDependencyExtension
    {
        public static void UseSqlTableDependency(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var service = serviceProvider.GetService<ProductTable>();
                service.TableDependencySetup();
            }
        
        }
    }

}
