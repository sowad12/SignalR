using Main.Manager.Implementation;
using Main.Manager.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Main.Hubs
{
    public class DashboardHub:Hub
    {
        private readonly IProductManager _productManager;
        public DashboardHub(IProductManager productManager)
        {

            _productManager = productManager;
        }
        public async Task SendProducts()
        {
            var products=_productManager.GetAllProducts();
            await Clients.All.SendAsync("ReceiveProducts", products);

        }
    }

}
