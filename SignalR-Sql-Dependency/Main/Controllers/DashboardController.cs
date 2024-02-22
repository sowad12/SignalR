using Library.Model.ViewModel;
using Main.Hubs;
using Main.Manager.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductManager _productManager;
     
        public DashboardController(IProductManager productManager)
        {
            _productManager= productManager;
         
        }
        public IActionResult Index()
        {
            //var model = new ProductViewModel();
            //var data= _productManager.GetAllProducts();
            //_dashboardHub.
            ////model.Products = data;
            //return View(model);
            return View();
        }
    }
}
