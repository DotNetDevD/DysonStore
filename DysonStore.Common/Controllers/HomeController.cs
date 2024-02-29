using DysonStore.Common.Models;
using DysonStore.Common.Models.DTOs;
using DysonStore.Common.Repositories;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Diagnostics;

namespace DysonStore.Common.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(int categoryId = 0)
        {
            IEnumerable<Product> products = await _homeRepository.GetProducts(categoryId);
            IEnumerable<Category> categories = await _homeRepository.Categories();
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
            var product = await _homeRepository.GetProductAsync(id);

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
