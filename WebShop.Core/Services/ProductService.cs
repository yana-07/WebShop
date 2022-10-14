using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebShop.Core.Contracts;
using WebShop.Core.Data.Models;
using WebShop.Core.Models;
using WebShopDemo.Core.Data.Common;

namespace WebShop.Core.Services
{
    /// <summary>
    /// Manipulate product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        private readonly IRepository repo;

        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(
            IConfiguration _config, 
            IRepository _repo)
        {
            this.config = _config;
            this.repo = _repo;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        public async Task AddAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
            };

            await this.repo.AddAsync<Product>(product);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await this.repo.All<Product>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsActive = false;
                await repo.SaveChangesAsync();
            }        
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            //string dataPath = this.config.GetSection("DataFiles:Products").Value;

            //string dataPath = this.config["DataFiles:Products"];
            //string data = await File.ReadAllTextAsync(dataPath);
            //return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(data);

            return await this.repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                }).ToListAsync();
        }
    }
}
