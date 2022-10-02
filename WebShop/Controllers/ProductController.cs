﻿using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Contracts;

namespace WebShop.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
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
        public async Task <IActionResult> Index()
        {
            var products = await this.productService.GetAllAsync();
            return View(products);
        }
    }
}