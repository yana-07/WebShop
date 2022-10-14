using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Contracts;
using WebShop.Core.Models;

namespace WebShop.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }
        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        //[AllowAnonymous]
        public async Task <IActionResult> Index()
        {
            var products = await this.productService.GetAllAsync();
            return View(products);
        }

        public IActionResult Add()
        {
            var model = new ProductDto();
            ViewData["Title"] = "Add new product";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto input)
        {
            ViewData["Title"] = "Add new product";

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.productService.AddAsync(input);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await this.productService.Delete(id);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
