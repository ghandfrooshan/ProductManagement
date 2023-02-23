using Microsoft.AspNetCore.Mvc;
using ProductManagement.App.Models;
using ProductManagement.ProductContext.Facade.Contracts.Products;
using ProductManagement.ReadModel.Queries.Contracts;
using System.Diagnostics;

namespace ProductManagement.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IProductQueryFacade productQueryFacade, IProductCommandfacade productCommandfacade)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
