using WebShop.Core.Models;

namespace WebShop.Core.Contracts
{
    /// <summary>
    /// Manipulate product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GetAllAsync();

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        Task AddAsync(ProductDto productDto);    

        Task Delete(Guid id);
    }
}
