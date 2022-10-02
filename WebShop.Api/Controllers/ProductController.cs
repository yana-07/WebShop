﻿using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Contracts;
using WebShop.Core.Models;

namespace WebShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_productService"></param>
        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetAll()
        {
            return this.Ok(await this.productService.GetAllAsync());
        }
    }
}
