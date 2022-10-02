using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebShop.Core.Contracts;
using WebShop.Core.Models;

namespace WebShop.Core.Services
{
    /// <summary>
    /// Manipulate product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(IConfiguration _config)
        {
            this.config = _config;  
        }
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            //string dataPath = this.config.GetSection("DataFiles:Products").Value;
            string dataPath = this.config["DataFiles:Products"];
            string data = await File.ReadAllTextAsync(dataPath);
            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(data);
        }
    }
}
