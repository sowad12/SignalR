using Library.Infrastructer.Options;
using Library.Model.ViewModel;
using Main.Hubs;
using Main.Manager.Interface;
using Microsoft.Extensions.Options;
using System;
using TableDependency.SqlClient;

namespace Main.SqlTableDependency
{
    public class ProductTable
    {
        private readonly DashboardHub _dashboardHub;
        private readonly DatabaseOptions _databaseOptions;
        private readonly IProductManager _productManager;

        public ProductTable(DashboardHub dashboardHub, IOptions<DatabaseOptions> databaseOptions, IProductManager productManager)
        {
            _dashboardHub = dashboardHub;
            _databaseOptions = databaseOptions.Value;
            _productManager = productManager;
        }

        public void TableDependencySetup()
        {
            var tableDependency = new SqlTableDependency<Product>(_databaseOptions.ConnectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                var products = _productManager.GetAllProducts();
                _dashboardHub.SendProducts(products);
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Product)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
