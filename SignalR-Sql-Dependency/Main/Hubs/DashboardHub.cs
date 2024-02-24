using System;
using System.Threading.Tasks;
using Library.Model.ViewModel;
using Main.Manager.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace Main.Hubs
{
    public class DashboardHub : Hub
    {
        

        public async Task SendProducts(List<Product> products)
        {
            try
            {              
                await Clients.All.SendAsync("ReceiveProducts", products);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error sending products: " + ex.Message);
            }
        }


    }
}
