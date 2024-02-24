using Library.Model.ViewModel;
using Main.Hubs;
using Main.Manager.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly DashboardHub _dashboardHub;
        public DashboardController(IProductManager productManager, DashboardHub dashboardHub)
        {
            _productManager = productManager;
            _dashboardHub = dashboardHub;
        }
        [HttpGet]
        public IActionResult Index()
        {
             var products = _productManager.GetAllProducts();
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Products = products;         
            return View(viewModel);
        }
    }
}
