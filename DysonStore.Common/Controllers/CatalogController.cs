using DysonStore.Common.Models;
using DysonStore.Common.Models.DTOs;
using DysonStore.Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DysonStore.Common.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly IProductRepository _productRepository;

        public CatalogController(ILogger<CatalogController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int categoryId = 0)
        {
            IEnumerable<Product> products = await _productRepository.GetProducts(categoryId);
            IEnumerable<Category> categories = await _productRepository.Categories();
            ProductDisplayView bookModel = new ProductDisplayView
            {
                Products = products,
                Categories = categories,
                CategoryId = categoryId
            };

            return View(bookModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetProductAsync(id);

            return View(product);
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
