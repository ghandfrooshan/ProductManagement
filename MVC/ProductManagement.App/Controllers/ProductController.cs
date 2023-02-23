
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.App.HtmlHelpers;

using ProductManagement.App.Models.Product;
using ProductManagement.ProductContext.ApplicationService.Contracts.Products;
using ProductManagement.ProductContext.Facade.Contracts.Products;
using ProductManagement.ReadModel.Queries.Contracts;
using ProductManagement.ReadModel.Queries.Contracts.DataContract;

namespace ProductManagement.App.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductQueryFacade productQueryFacade;
        private readonly IProductCommandfacade productCommandfacade;


        public ProductController(ILogger<ProductController> logger,
            IProductQueryFacade productQueryFacade, IProductCommandfacade productCommandfacade)
        {
            _logger = logger;
            this.productQueryFacade = productQueryFacade;
            this.productCommandfacade = productCommandfacade;

        }


        [HttpGet]
        public IActionResult Index()
        {

            var products = productQueryFacade.GetAllProduct();

            ViewBag.Category = productQueryFacade.GetCategories();

            return View(products);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = productQueryFacade.GetCategories();
            return View("_Create");
        }


        [HttpPost]
        public IActionResult Create(ProductCreateCommand command)
        {

            productCommandfacade.CreateProduct(command);
            var products = productQueryFacade.GetAllProduct();
            return PartialView("_TableBody", products);

        }
        [HttpPost]
        public IActionResult Delete(ProductDeleteCommand command)
        {
            productCommandfacade.DeleteProduct(command);
            var result = productQueryFacade.GetAllProduct();
            return PartialView("_TableBody", result);
        }

        [HttpPost]
        public IActionResult ActivateProduct(long productId)
        {

            var command = new ProductSetActiveCommand() { ProductId = productId, IsActice = true };
            productCommandfacade.SetActiveProduct(command);
            var result = productQueryFacade.GetAllProduct();
            return PartialView("_TableBody", result);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeactivateProduct(long productId)
        {

            var command = new ProductSetActiveCommand() { ProductId = productId, IsActice = false };
            productCommandfacade.SetActiveProduct(command);
            var result = productQueryFacade.GetAllProduct();
            return PartialView("_TableBody", result);
        }

        [HttpGet]
        public IActionResult Edit(long productId)
        {

            var product = productQueryFacade.GetProductById(productId);
            ViewBag.Category = productQueryFacade.GetCategories();

            return PartialView("_Edit", product);
        }
        [HttpPost]
        public IActionResult Edit(ProductUpdateCommand command)
        {
            productCommandfacade.UpdateProduct(command);
            var result = productQueryFacade.GetAllProduct();
            return PartialView("_TableBody", result);
        }
        [HttpPost]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
            IEnumerable<ProductWithPriceDto> result ;
            if (categoryId != 0)
                result = productQueryFacade.GetProductsByCategoryId(categoryId);
            else
                result = productQueryFacade.GetAllProduct();
            return PartialView("_TableBody", result);
        }
    }
}